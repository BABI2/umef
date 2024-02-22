using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Org.BouncyCastle.Asn1.Pkcs;

namespace Site_De_Swiss_UMEF.Models
{
    public class MailService : IMailService
    {

        private readonly SmtpSettings _settings;

        public MailService(IOptions<SmtpSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<bool> SendAsync(MailData mailData,SmtpSettings smtpSettings, CancellationToken ct = default)
        {
            try
            {
                // Initialize a new instance of the MimeKit.MimeMessage class
                var mail = new MimeMessage();

                #region Sender / Receiver
                // Sender
                mail.From.Add(MailboxAddress.Parse(smtpSettings.SenderEmail));
                //mail.From.Add(new MailboxAddress(_settings.SenderName, mailData.From ?? _settings.SenderEmail));
                //mail.Sender = new MailboxAddress(mailData.DisplayName ?? _settings.SenderName, mailData.From ?? _settings.SenderEmail);

                // Receiver
                foreach (string mailAddress in mailData.To)
                    mail.To.Add(MailboxAddress.Parse(mailAddress));

                // Set Reply to if specified in mail data
                if (!string.IsNullOrEmpty(mailData.ReplyTo))
                    mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

                // BCC
                // Check if a BCC was supplied in the request
                if (mailData.Bcc != null)
                {
                    // Get only addresses where value is not null or with whitespace. x = value of address
                    foreach (string mailAddress in mailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
                        mail.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                }

                // CC
                // Check if a CC address was supplied in the request
                if (mailData.Cc != null)
                {
                    foreach (string mailAddress in mailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
                        mail.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
                }
                #endregion

                #region Content

                // Add Content to Mime Message
                var body = new BodyBuilder();
                mail.Subject = mailData.Subject;
                body.HtmlBody = mailData.Body;
                mail.Body = body.ToMessageBody();

                #endregion

                #region Send Mail

                using var smtp = new SmtpClient();

                if (smtpSettings.UseSSL)
                {
                    await smtp.ConnectAsync(smtpSettings.Host, smtpSettings.Port, SecureSocketOptions.SslOnConnect, ct);
                }
                else if (smtpSettings.UseStartTls)
                {
                    await smtp.ConnectAsync(smtpSettings.Host, smtpSettings.Port, SecureSocketOptions.StartTls, ct);
                }
                await smtp.AuthenticateAsync(smtpSettings.Username, smtpSettings.Password, ct);
                await smtp.SendAsync(mail, ct);
                await smtp.DisconnectAsync(true, ct);

                #endregion

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

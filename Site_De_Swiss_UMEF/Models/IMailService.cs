using Org.BouncyCastle.Asn1.Pkcs;

namespace Site_De_Swiss_UMEF.Models
{
    public interface IMailService
    {
        Task<bool> SendAsync(MailData mailData, SmtpSettings smtpSettings, CancellationToken ct);
    }
}

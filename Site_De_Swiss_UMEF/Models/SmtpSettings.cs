namespace Site_De_Swiss_UMEF.Models
{
    //[PrimaryKey(nameof(Id))]
    public class SmtpSettings
    {
        public int Id { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? SenderName { get; set; }
        public string? SenderEmail { get; set; }
        public bool UseSSL { get; set; } = false;
        public bool UseStartTls { get; set; } = true;
    }
}

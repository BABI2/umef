using System.ComponentModel.DataAnnotations;

namespace Site_De_Swiss_UMEF.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}

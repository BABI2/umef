using Microsoft.AspNetCore.Identity;

namespace Site_De_Swiss_UMEF.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}

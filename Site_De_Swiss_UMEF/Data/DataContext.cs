using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Site_De_Swiss_UMEF.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> User { get; set; }
        public DbSet<SmtpSettings> SmtpSettings { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleImage> ArticleImageSlider { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
    }
}

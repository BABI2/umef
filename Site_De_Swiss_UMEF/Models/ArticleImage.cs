namespace Site_De_Swiss_UMEF.Models
{
    public class ArticleImage
    {
        [Key]
        public int id_imgslide { get; set; }
        public string lien { get; set; } = string.Empty;
        public DateTime create_at { get; set; } = DateTime.Now;
        public DateTime update_at { get; set; } = DateTime.Now;
        [ForeignKey("Articles")]
        public int id_article { get; set; } 
    }
}

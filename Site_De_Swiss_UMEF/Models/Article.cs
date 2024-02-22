namespace Site_De_Swiss_UMEF.Models
{

    public class Article
    {
        [Key]
        public int id_article { get; set; }
        public string title { get; set; } = string.Empty;
        public string content { get; set; }= string.Empty;
        public string image_article { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string icons { get; set; } = string.Empty;
        [ForeignKey("Categories")]
        public int id_categorie { get; set; }
        public DateTime create_at { get; set; } = DateTime.Now;
        public DateTime update_at { get; set; } = DateTime.Now;
        public List<Subscriber>? Subscribers { get; set; }
    }
}

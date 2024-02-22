namespace Site_De_Swiss_UMEF.Models
{
    public class Categorie
    {
        [Key]
        public int id_categorie { get; set; } 
        public string display_name { get; set; } = string.Empty;
        public DateTime create_at { get; set; } = DateTime.Now;
        public DateTime update_at { get; set;} = DateTime.Now;

    }
}

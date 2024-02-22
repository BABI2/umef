namespace Site_De_Swiss_UMEF.Models
{
    
    public class Subscriber
    {
        [Key]
        int _id;
        string? _email;
        string? _fullName;
        //bool? _isSubscribe; // False si la personne ce desabonne
        DateTime _dateInscription;
        List<Article>? _article;

        public int Id { get => _id; set => _id = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? FullName { get => _fullName; set => _fullName = value; }
        public DateTime DateInscription { get => _dateInscription; set => _dateInscription = value; }
        public List<Article>? Articles { get => _article; set => _article = value; }
        //public bool? IsSubscribe { get => _isSubscribe; set => _isSubscribe = value; }
    }
}

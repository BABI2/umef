using Site_De_Swiss_UMEF.Models;

namespace Site_De_Swiss_UMEF.ViewComponents
{
    public class ArticleSliderViewComponent : ViewComponent
    {
        private readonly DataContext _db;
        public ArticleSliderViewComponent(DataContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<SousListes> Maliste = new List<SousListes>();
            IEnumerable<ArticleImage> Images = _db.ArticleImageSlider;
            foreach (ArticleImage image in Images)
            {
                Maliste.Add(new SousListes() {Id = image.id_article, Chaines = image.lien });
            }
            ViewBag.liste= Maliste;
            Categorie categ = _db.Categories.Where(c => c.display_name == "ArticleSlider").First();
            IEnumerable<Article> obj = _db.Articles.Where(a => a.id_categorie == categ.id_categorie);
            return await Task.FromResult(View(obj));
        }
        
    }
}

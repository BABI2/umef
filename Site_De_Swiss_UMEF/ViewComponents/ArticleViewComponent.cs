namespace Site_De_Swiss_UMEF.ViewComponents
{
    public class ArticleViewComponent : ViewComponent
    {
        private readonly DataContext _db;
        public ArticleViewComponent(DataContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(string title)
        {
            Article obj = _db.Articles.Where(a => a.title == title).First();
            return View(obj);
        }

    }
}

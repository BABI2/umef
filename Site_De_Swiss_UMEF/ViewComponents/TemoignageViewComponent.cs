namespace Site_De_Swiss_UMEF.ViewComponents
{
    public class TemoignageViewComponent : ViewComponent
    {
        private readonly DataContext _db;
        public TemoignageViewComponent(DataContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Categorie cat = _db.Categories.Where(c =>c.display_name== "Temoignage").First();//Recuperation de l'ID de Temoignage
            var obj = _db.Articles.Where(a => a.id_categorie== cat.id_categorie); //Recuperation de tous les temoignages
            return await Task.FromResult(View(obj));
        }
    }
}

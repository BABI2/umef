namespace Site_De_Swiss_UMEF.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly DataContext _db;

        public HomeController(ILogger<HomeController> logger, DataContext db)
		{
			_logger = logger;
			_db = db;
		}
		public IActionResult Index()
		{
            IEnumerable<Article> obj = _db.Articles;
            return View(obj);
		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        //Return Id user connect
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
        public IActionResult Temoignage()
        {
            return View("Views/Pages/Temoignage.cshtml");
        }


        public IActionResult Formation_Bachelor()
		{
			return View("Views/Pages/Formation_Bachelor.cshtml");
		}

        public IActionResult Formation_Master()
        {
            return View("Views/Pages/Formation_Master.cshtml");
        }

        public IActionResult Bachelor()
        {
            return View("Views/Pages/Bachelor.cshtml");
        }

        public IActionResult Master()
        {
            return View("Views/Pages/Master.cshtml");
        }

        public IActionResult Nouveau_Campus()
        {
            return View("Views/Pages/Nouveau_Campus.cshtml");
        }

        //public IActionResult Contact()
        //{
        //    return View("Views/Pages/Contact.cshtml");
        //}

        public IActionResult Ecole_Ingenieur()
        {
            return View("Views/Pages/Ecole_Ingenieur.cshtml");
        }

        public IActionResult Ecole_Doctorale()
        {
            return View("Views/Pages/Ecole_Doctorale.cshtml");
        }

        public IActionResult Formations_Continues()
        {
            return View("Views/Pages/Formations_Continues.cshtml");
        }

        public IActionResult Etudiant_Formation()
        {
            return View("Views/Pages/Etudiant_formation.cshtml");
        }

        public IActionResult Renforcement()
        {
            return View("Views/Pages/Renforcement.cshtml");
        }

        public IActionResult Entreprenariat_UMEF()
        {
            return View("Views/Pages/Entreprenariat_UMEF.cshtml");
        }

        public IActionResult Fonctionnaires()
        {
            return View("Views/Pages/Fonctionnaires.cshtml");
        }

        // recherche barre
        public IActionResult? Recherche(string Search)
        {
            ViewData["Search"] = Search;
            if (Search != null)
            {
                IEnumerable<Article> obj = _db.Articles;
                IEnumerable<Article>? trouver = from article in obj
                                                where article.title.Contains(Search) || article.content.Contains(Search)
                                                select article;
                if (trouver.Count() > 0) return View("Views/Pages/Recherche.cshtml",trouver);
            }
            
            return View("Views/Pages/Recherche.cshtml", null);
        }

    }
}
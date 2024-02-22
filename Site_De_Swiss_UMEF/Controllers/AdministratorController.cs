using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;
using Site_De_Swiss_UMEF.Data;
using Site_De_Swiss_UMEF.Models;
using MailKit;
using IMailService = Site_De_Swiss_UMEF.Models.IMailService;
using Org.BouncyCastle.Asn1.Pkcs;

namespace Site_De_Swiss_UMEF.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly DataContext _db;
        private readonly IMailService _mail;
        public AdministratorController(DataContext db,IMailService mail)
        {
            _db = db;
            _mail = mail;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SendNewsletter(int Id)
        {
            var articles = _db.Articles.Find(Id);

            var subscribers = _db.Subscribers.ToList();
            List<string> To = new();
            foreach (var subscriber in subscribers)
            {
                To.Add(subscriber.Email);
            }
            MailData mailDatamail = new MailData(To, articles.title, articles.content, "Umef Niger", "", "", "");
            var result =  _mail.SendAsync(mailDatamail,_db.SmtpSettings.First(), new CancellationToken());

            return RedirectToAction("Index");
        }
        public IActionResult ListOfArticle()
        {
            IEnumerable<Article> obj = _db.Articles;
            return View(obj);
        }
        public IActionResult ListOfCategory()
        {
            IEnumerable<Categorie> obj = _db.Categories;
            return View(obj);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Article art)
        {
            if (ModelState.IsValid)
            {
                _db.Add(art);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(art);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(Categorie cat)
        {
            if (ModelState.IsValid)
            {
                _db.Add(cat);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cat);
        }


        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.Articles == null)
            {
                return NotFound();
            }

            var article = await _db.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Article article)
        {
            if (id != article.id_article)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(article);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.id_article))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        private bool ArticleExists(int id)
        {
            return _db.Articles.Any(e => e.id_article == id);
        }
    }
}

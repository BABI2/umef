using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site_De_Swiss_UMEF.Data;
using Site_De_Swiss_UMEF.Models;

namespace Site_De_Swiss_UMEF.Controllers
{
    public class SmtpSettingsController : Controller
    {
        private readonly DataContext _context;

        public SmtpSettingsController(DataContext context)
        {
            _context = context;
        }

        // GET: SmtpSettings
        public async Task<IActionResult> Index()
        {
              return View(await _context.SmtpSettings.ToListAsync());
        }

        // GET: SmtpSettings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SmtpSettings == null)
            {
                return NotFound();
            }

            var smtpSettings = await _context.SmtpSettings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (smtpSettings == null)
            {
                return NotFound();
            }

            return View(smtpSettings);
        }

        // GET: SmtpSettings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SmtpSettings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Host,Port,Username,Password,SenderName,SenderEmail,UseSSL,UseStartTls")] SmtpSettings smtpSettings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(smtpSettings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(smtpSettings);
        }

        // GET: SmtpSettings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SmtpSettings == null)
            {
                return NotFound();
            }

            var smtpSettings = await _context.SmtpSettings.FindAsync(id);
            if (smtpSettings == null)
            {
                return NotFound();
            }
            return View(smtpSettings);
        }

        // POST: SmtpSettings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Host,Port,Username,Password,SenderName,SenderEmail,UseSSL,UseStartTls")] SmtpSettings smtpSettings)
        {
            if (id != smtpSettings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(smtpSettings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmtpSettingsExists(smtpSettings.Id))
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
            return View(smtpSettings);
        }

        // GET: SmtpSettings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SmtpSettings == null)
            {
                return NotFound();
            }

            var smtpSettings = await _context.SmtpSettings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (smtpSettings == null)
            {
                return NotFound();
            }

            return View(smtpSettings);
        }

        // POST: SmtpSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SmtpSettings == null)
            {
                return Problem("Entity set 'DataContext.SmtpSettings'  is null.");
            }
            var smtpSettings = await _context.SmtpSettings.FindAsync(id);
            if (smtpSettings != null)
            {
                _context.SmtpSettings.Remove(smtpSettings);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SmtpSettingsExists(int id)
        {
          return (_context.SmtpSettings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

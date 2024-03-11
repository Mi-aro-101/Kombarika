using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository;
using MvcTest_Ef.Models;

namespace MvcTest_Ef.Controllers
{
    public class MatierePremiereController : Controller
    {
        private DatabaseContext _context;

        public MatierePremiereController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: MatierePremiere
        public async Task<IActionResult> Index()
        {
            return View(await _context.MatierePremieres.ToListAsync());
        }

        // GET: MatierePremiere/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matierePremiere = await _context.MatierePremieres
                .FirstOrDefaultAsync(m => m.IdMatierePremiere == id);
            if (matierePremiere == null)
            {
                return NotFound();
            }

            return View(matierePremiere);
        }

        // GET: MatierePremiere/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MatierePremiere/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMatierePremiere,Designation,PrixUnitaire")] MatierePremiere matierePremiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matierePremiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matierePremiere);
        }

        // GET: MatierePremiere/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matierePremiere = await _context.MatierePremieres.FindAsync(id);
            if (matierePremiere == null)
            {
                return NotFound();
            }
            return View(matierePremiere);
        }

        // POST: MatierePremiere/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMatierePremiere,Designation,PrixUnitaire")] MatierePremiere matierePremiere)
        {
            if (id != matierePremiere.IdMatierePremiere)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matierePremiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatierePremiereExists(matierePremiere.IdMatierePremiere))
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
            return View(matierePremiere);
        }

        // GET: MatierePremiere/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matierePremiere = await _context.MatierePremieres
                .FirstOrDefaultAsync(m => m.IdMatierePremiere == id);
            if (matierePremiere == null)
            {
                return NotFound();
            }

            return View(matierePremiere);
        }

        // POST: MatierePremiere/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matierePremiere = await _context.MatierePremieres.FindAsync(id);
            if (matierePremiere != null)
            {
                _context.MatierePremieres.Remove(matierePremiere);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatierePremiereExists(int id)
        {
            return _context.MatierePremieres.Any(e => e.IdMatierePremiere == id);
        }

        public override bool Equals(object? obj)
        {
            return obj is MatierePremiereController controller &&
                   EqualityComparer<DatabaseContext>.Default.Equals(_context, controller._context);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}

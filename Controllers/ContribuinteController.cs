using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeneficioContribuinte.Models;


namespace BeneficioContribuinte.Controllers
{
    public class ContribuinteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContribuinteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contribuinte
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Contribuintes.Include(c => c.Beneficio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Contribuinte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contribuinte = await _context.Contribuintes
                .Include(c => c.Beneficio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contribuinte == null)
            {
                return NotFound();
            }

            return View(contribuinte);
        }

        // GET: Contribuinte/Create
        public IActionResult Create()
        {
            ViewData["BeneficioId"] = new SelectList(_context.Beneficios, "Id", "Nome");
            return View();
        }

        // POST: Contribuinte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CNPJ,RazaoSocial,DataAbertura,RegimeTributacao,BeneficioId")] Contribuinte contribuinte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contribuinte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contribuinte);
        }

        // GET: Contribuinte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contribuinte = await _context.Contribuintes.FindAsync(id);
            if (contribuinte == null)
            {
                return NotFound();
            }
            ViewData["BeneficioId"] = new SelectList(_context.Beneficios, "Id", "Nome", contribuinte.BeneficioId);
            return View(contribuinte);
        }

        // POST: Contribuinte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CNPJ,RazaoSocial,DataAbertura,RegimeTributacao,BeneficioId")] Contribuinte contribuinte)
        {
            if (id != contribuinte.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contribuinte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContribuinteExists(contribuinte.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contribuinte);
        }

        // GET: Contribuinte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contribuinte = await _context.Contribuintes
                .Include(c => c.Beneficio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contribuinte == null)
            {
                return NotFound();
            }

            return View(contribuinte);
        }

        // POST: Contribuinte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contribuinte = await _context.Contribuintes.FindAsync(id);
            if (contribuinte != null)
            {
                _context.Contribuintes.Remove(contribuinte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContribuinteExists(int id)
        {
            return _context.Contribuintes.Any(e => e.Id == id);
        }
    }
}

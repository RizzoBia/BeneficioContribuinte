using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeneficioContribuinte.Models;

namespace BeneficioContribuinte.Controllers
{
    public class BeneficioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeneficioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Beneficio
        public async Task<IActionResult> Index()
        {
            return View(await _context.Beneficios.ToListAsync());
        }

        // GET: Beneficio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficio = await _context.Beneficios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beneficio == null)
            {
                return NotFound();
            }

            return View(beneficio);
        }

        // GET: Beneficio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beneficio/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,PercentualDesconto")] Beneficio beneficio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beneficio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beneficio);
        }

        // GET: Beneficio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficio = await _context.Beneficios.FindAsync(id);
            if (beneficio == null)
            {
                return NotFound();
            }
            return View(beneficio);
        }

        // POST: Beneficio/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,PercentualDesconto")] Beneficio beneficio)
        {
            if (id != beneficio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beneficio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeneficioExists(beneficio.Id))
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
            return View(beneficio);
        }

        // GET: Beneficio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficio = await _context.Beneficios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beneficio == null)
            {
                return NotFound();
            }

            return View(beneficio);
        }

        // POST: Beneficio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // Busca o benefício no banco de dados
                var beneficio = await _context.Beneficios.FindAsync(id);

                if (beneficio == null)
                {
                    TempData["ErrorMessage"] = "Benefício não encontrado.";
                    return RedirectToAction(nameof(Index));
                }

                // Remove o benefício
                _context.Beneficios.Remove(beneficio);

                // Salva as mudanças no banco de dados
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Benefício excluído com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log do erro (caso queira)
                Console.WriteLine($"Erro ao excluir benefício: {ex.Message}");

                TempData["ErrorMessage"] = "Erro ao excluir o benefício. Tente novamente.";
                return RedirectToAction(nameof(Index));
            }
        }

        // Método para verificar se um benefício existe
        private bool BeneficioExists(int id)
        {
            return _context.Beneficios.Any(e => e.Id == id);
        }
    }
}

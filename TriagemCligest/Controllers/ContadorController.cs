using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TriagemCligest.Data;
using TriagemCligest.Models;

namespace TriagemCligest.Controllers
{
    public class ContadorController : Controller
    {
        private readonly CligestMainContext _context;

        public ContadorController(CligestMainContext context)
        {
            _context = context;
        }

        // GET: Contador
        public async Task<IActionResult> Index()
        {
              return _context.Contador != null ? 
                          View(await _context.Contador.ToListAsync()) :
                          Problem("Entity set 'CligestMainContext.Contador'  is null.");
        }

        // GET: Contador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contador == null)
            {
                return NotFound();
            }

            var contador = await _context.Contador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contador == null)
            {
                return NotFound();
            }

            return View(contador);
        }

        // GET: Contador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,_Contador,Valor,IdCompany,Ano,IDCentroCusto")] Contador contador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contador);
        }

        // GET: Contador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contador == null)
            {
                return NotFound();
            }

            var contador = await _context.Contador.FindAsync(id);
            if (contador == null)
            {
                return NotFound();
            }
            return View(contador);
        }

        // POST: Contador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,_Contador,Valor,IdCompany,Ano,IDCentroCusto")] Contador contador)
        {
            if (id != contador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContadorExists(contador.Id))
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
            return View(contador);
        }

        // GET: Contador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contador == null)
            {
                return NotFound();
            }

            var contador = await _context.Contador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contador == null)
            {
                return NotFound();
            }

            return View(contador);
        }

        // POST: Contador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contador == null)
            {
                return Problem("Entity set 'CligestMainContext.Contador'  is null.");
            }
            var contador = await _context.Contador.FindAsync(id);
            if (contador != null)
            {
                _context.Contador.Remove(contador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContadorExists(int id)
        {
          return (_context.Contador?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

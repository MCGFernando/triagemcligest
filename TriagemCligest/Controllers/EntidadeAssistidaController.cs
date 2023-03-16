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
    public class EntidadeAssistidaController : Controller
    {
        private readonly CligestMainContext _context;

        public EntidadeAssistidaController(CligestMainContext context)
        {
            _context = context;
        }

        // GET: EntidadeAssistida
        public async Task<IActionResult> Index()
        {
              return _context.EntidadeAssistida != null ? 
                          View(await _context.EntidadeAssistida.ToListAsync()) :
                          Problem("Entity set 'CligestMainContext.EntidadeAssistida'  is null.");
        }

        // GET: EntidadeAssistida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EntidadeAssistida == null)
            {
                return NotFound();
            }

            var entidadeAssistida = await _context.EntidadeAssistida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entidadeAssistida == null)
            {
                return NotFound();
            }

            return View(entidadeAssistida);
        }

        // GET: EntidadeAssistida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntidadeAssistida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Entidade,TipoDeContracto,Activa,Sigla,NDeContaCorrente,ClienteExterno,Actualizada,Protocolo,TipoDeAtendimento,DataDeActualizacao,Precario,Localizacao,Destinatario1,Destinatario2,IdFooter,GestorDeConta,ProtocoloFacturacao,NDeContribuinte,Morada,IdPrecario,ForceCode,MaskCode,CodeExample,IdSerie,GeraFactura,BI,Cartao,Guia,Checkup,USD,IVA,Flag1,Flag2")] EntidadeAssistida entidadeAssistida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entidadeAssistida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entidadeAssistida);
        }

        // GET: EntidadeAssistida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EntidadeAssistida == null)
            {
                return NotFound();
            }

            var entidadeAssistida = await _context.EntidadeAssistida.FindAsync(id);
            if (entidadeAssistida == null)
            {
                return NotFound();
            }
            return View(entidadeAssistida);
        }

        // POST: EntidadeAssistida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Entidade,TipoDeContracto,Activa,Sigla,NDeContaCorrente,ClienteExterno,Actualizada,Protocolo,TipoDeAtendimento,DataDeActualizacao,Precario,Localizacao,Destinatario1,Destinatario2,IdFooter,GestorDeConta,ProtocoloFacturacao,NDeContribuinte,Morada,IdPrecario,ForceCode,MaskCode,CodeExample,IdSerie,GeraFactura,BI,Cartao,Guia,Checkup,USD,IVA,Flag1,Flag2")] EntidadeAssistida entidadeAssistida)
        {
            if (id != entidadeAssistida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entidadeAssistida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntidadeAssistidaExists(entidadeAssistida.Id))
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
            return View(entidadeAssistida);
        }

        // GET: EntidadeAssistida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EntidadeAssistida == null)
            {
                return NotFound();
            }

            var entidadeAssistida = await _context.EntidadeAssistida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entidadeAssistida == null)
            {
                return NotFound();
            }

            return View(entidadeAssistida);
        }

        // POST: EntidadeAssistida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EntidadeAssistida == null)
            {
                return Problem("Entity set 'CligestMainContext.EntidadeAssistida'  is null.");
            }
            var entidadeAssistida = await _context.EntidadeAssistida.FindAsync(id);
            if (entidadeAssistida != null)
            {
                _context.EntidadeAssistida.Remove(entidadeAssistida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntidadeAssistidaExists(int id)
        {
          return (_context.EntidadeAssistida?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

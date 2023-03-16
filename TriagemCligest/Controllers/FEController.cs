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
    public class FEController : Controller
    {
        private readonly CligestSIContext _context;

        public FEController(CligestSIContext context)
        {
            _context = context;
        }

        // GET: FE
        public async Task<IActionResult> Index()
        {
              return _context.FE != null ? 
                          View(await _context.FE.Take(15).ToListAsync()) :
                          Problem("Entity set 'CligestSIContext.FE'  is null.");
        }

        // GET: FE/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FE == null)
            {
                return NotFound();
            }

            var fE = await _context.FE
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fE == null)
            {
                return NotFound();
            }

            return View(fE);
        }

        // GET: FE/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NDocumento,DataDeEmissao,DatadoDocumento,Destinatario,Destinatario2,DefaultEXT,DefaultUtente,DefaultCoef,DefaultData,DefaultArea,DefaultItem,IdFooter,Total,Desconto,Autorizacao,Idfuncionario,Estado,IdTipodeDocumento,IdEntidade,IdTipoDeEntidade,Entidade,Kwanzas,Proforma,DataDeEntrada,DataDeSaida,NdeProcesso,Pago,Cambio,TotalKwanzas,IdFuncionarioLast,Hora,Data,Precario,Integrado,Lancamento,Localizacao,CodigoContaCorrente,FuncionarioQueAdmitiu,Operador,TipoDeEpisodio,Notas,Marcacao,CentroDeResponsabilidade,ICD10,IvaTotal")] FE fE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fE);
        }

        // GET: FE/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FE == null)
            {
                return NotFound();
            }

            var fE = await _context.FE.FindAsync(id);
            if (fE == null)
            {
                return NotFound();
            }
            return View(fE);
        }

        // POST: FE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NDocumento,DataDeEmissao,DatadoDocumento,Destinatario,Destinatario2,DefaultEXT,DefaultUtente,DefaultCoef,DefaultData,DefaultArea,DefaultItem,IdFooter,Total,Desconto,Autorizacao,Idfuncionario,Estado,IdTipodeDocumento,IdEntidade,IdTipoDeEntidade,Entidade,Kwanzas,Proforma,DataDeEntrada,DataDeSaida,NdeProcesso,Pago,Cambio,TotalKwanzas,IdFuncionarioLast,Hora,Data,Precario,Integrado,Lancamento,Localizacao,CodigoContaCorrente,FuncionarioQueAdmitiu,Operador,TipoDeEpisodio,Notas,Marcacao,CentroDeResponsabilidade,ICD10,IvaTotal")] FE fE)
        {
            if (id != fE.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FEExists(fE.Id))
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
            return View(fE);
        }

        // GET: FE/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FE == null)
            {
                return NotFound();
            }

            var fE = await _context.FE
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fE == null)
            {
                return NotFound();
            }

            return View(fE);
        }

        // POST: FE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FE == null)
            {
                return Problem("Entity set 'CligestSIContext.FE'  is null.");
            }
            var fE = await _context.FE.FindAsync(id);
            if (fE != null)
            {
                _context.FE.Remove(fE);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FEExists(int id)
        {
          return (_context.FE?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

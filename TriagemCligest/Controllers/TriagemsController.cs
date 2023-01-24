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
    public class TriagemsController : Controller
    {
        private readonly TriagemContext _context;

        public TriagemsController(TriagemContext context)
        {
            _context = context;
        }

        // GET: Triagems
        public async Task<IActionResult> Index()
        {
            var triagemContext = _context.Triagem.Include(t => t.Marcacao).Include(t => t.Utente);
            return View(await triagemContext.ToListAsync());
        }

        // GET: Triagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Triagem == null)
            {
                return NotFound();
            }

            var triagem = await _context.Triagem
                .Include(t => t.Marcacao)
                .Include(t => t.Utente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (triagem == null)
            {
                return NotFound();
            }

            return View(triagem);
        }

        // GET: Triagems/Create
        public IActionResult Create()
        {
            //ViewData["MarcacaoID"] = new SelectList(_context.Set<Marcacao>(), "ID", "ID");
            //ViewData["UtenteID"] = new SelectList(_context.Set<Utente>(), "ID", "ID");

            return View();
        }

        // POST: Triagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UtenteID,MarcacaoID,TipoTriagem,SituacaoQueixa,TensaoArterialSitolica,TensaoArterialDiastolica,Temperatura,ClassificacaoTemperatura,Peso,FrequeciaCardiaca,ClassificacaoFrequenciaCardiaca,FrequeciaRespiratoria,ClassificacaoFrequenciaRespiratoria,Patologia,DescricaoPatologia,Alergia,DescricaoAlergia,Medicamento,DescricaoMedicamento,ClassificacaoPeleMucosa,Ictericia,LesaoCutanea,ClassificacaoQueimadura,LocalQueimadura,Epistaxe,Cianose,Tosse,Expectoracao,ClassificacaoExpectoracao,SaturacaoOxigenio,LocalSianose,ClassificacaoGenitoUrinario,Metrorragia,Dismenorreia,SecrecaoUretralVaginal,Hematemese,Vomito,Melena,Enterorragia,Obstipacao,Diarreia,AtrasoMenstrual,Mioma,QuistosOvarios,CorrimentoVaginal,CaracteristicaCorrimentoVaginal,PruridoVaginal,Gravidez,MedicoAssistente,SemanaGravidez,ContracaoUterina,Hiperemese,Desidratacao,AbcessoMamario,IngurgitamentoMamario,DispneiaMusculaturaAcessoria,SangramentoNasal,FezesSangue,UrinaComSangue,DorMiccao,ClassificacaoColoracaoPele,ClassificacaoDiurese,DatarRgisto,HoraChegada,HoraAtendimentoMedico,HoraAcolhimento,ClassificacaoTriagem,EstadoTriagem")] Triagem triagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(triagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcacaoID"] = new SelectList(_context.Set<Marcacao>(), "ID", "ID", triagem.MarcacaoID);
            ViewData["UtenteID"] = new SelectList(_context.Set<Utente>(), "ID", "ID", triagem.UtenteID);
            return View(triagem);
        }

        // GET: Triagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Triagem == null)
            {
                return NotFound();
            }

            var triagem = await _context.Triagem.FindAsync(id);
            if (triagem == null)
            {
                return NotFound();
            }
            ViewData["MarcacaoID"] = new SelectList(_context.Set<Marcacao>(), "ID", "ID", triagem.MarcacaoID);
            ViewData["UtenteID"] = new SelectList(_context.Set<Utente>(), "ID", "ID", triagem.UtenteID);
            return View(triagem);
        }

        // POST: Triagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UtenteID,MarcacaoID,TipoTriagem,SituacaoQueixa,TensaoArterialSitolica,TensaoArterialDiastolica,Temperatura,ClassificacaoTemperatura,Peso,FrequeciaCardiaca,ClassificacaoFrequenciaCardiaca,FrequeciaRespiratoria,ClassificacaoFrequenciaRespiratoria,Patologia,DescricaoPatologia,Alergia,DescricaoAlergia,Medicamento,DescricaoMedicamento,ClassificacaoPeleMucosa,Ictericia,LesaoCutanea,ClassificacaoQueimadura,LocalQueimadura,Epistaxe,Cianose,Tosse,Expectoracao,ClassificacaoExpectoracao,SaturacaoOxigenio,LocalSianose,ClassificacaoGenitoUrinario,Metrorragia,Dismenorreia,SecrecaoUretralVaginal,Hematemese,Vomito,Melena,Enterorragia,Obstipacao,Diarreia,AtrasoMenstrual,Mioma,QuistosOvarios,CorrimentoVaginal,CaracteristicaCorrimentoVaginal,PruridoVaginal,Gravidez,MedicoAssistente,SemanaGravidez,ContracaoUterina,Hiperemese,Desidratacao,AbcessoMamario,IngurgitamentoMamario,DispneiaMusculaturaAcessoria,SangramentoNasal,FezesSangue,UrinaComSangue,DorMiccao,ClassificacaoColoracaoPele,ClassificacaoDiurese,DatarRgisto,HoraChegada,HoraAtendimentoMedico,HoraAcolhimento,ClassificacaoTriagem,EstadoTriagem")] Triagem triagem)
        {
            if (id != triagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(triagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TriagemExists(triagem.Id))
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
            ViewData["MarcacaoID"] = new SelectList(_context.Set<Marcacao>(), "ID", "ID", triagem.MarcacaoID);
            ViewData["UtenteID"] = new SelectList(_context.Set<Utente>(), "ID", "ID", triagem.UtenteID);
            return View(triagem);
        }

        // GET: Triagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Triagem == null)
            {
                return NotFound();
            }

            var triagem = await _context.Triagem
                .Include(t => t.Marcacao)
                .Include(t => t.Utente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (triagem == null)
            {
                return NotFound();
            }

            return View(triagem);
        }

        // POST: Triagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Triagem == null)
            {
                return Problem("Entity set 'TriagemContext.Triagem'  is null.");
            }
            var triagem = await _context.Triagem.FindAsync(id);
            if (triagem != null)
            {
                _context.Triagem.Remove(triagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TriagemExists(int id)
        {
          return _context.Triagem.Any(e => e.Id == id);
        }
    }
}

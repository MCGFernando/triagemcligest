using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;
using Newtonsoft.Json;
using TriagemCligest.Data;
using TriagemCligest.Models;
using TriagemCligest.Service;

namespace TriagemCligest.Controllers
{
    public class TriagemsController : Controller
    {
        private readonly TriagemContext _context;
        private readonly UtenteService _contextUtente;
        private readonly MarcacaoService _contextMarcacao;

        public TriagemsController(TriagemContext context, UtenteService contextUtente, MarcacaoService contextMarcacao)
        {
            _context = context;
            _contextUtente = contextUtente;
            _contextMarcacao = contextMarcacao;
        }

        // GET: Triagems
        public async Task<IActionResult> Index()
        {

            var queryTriagem = from t in _context.Triagem.ToList() select t;
            var queryUtente = from u in _contextUtente.FindAll() select u;
            var result = from a in queryTriagem join b in queryUtente on a.UtenteID equals b.ID select new { a, b };
            List<Triagem> lstTriagem = new List<Triagem>();
            foreach (var item in result)
            {
                Triagem triagem = item.a;
                triagem.Utente = item.b;
                lstTriagem.Add(triagem);
            }

            var utilizador = GetObjectFromSession();
            if (utilizador == null) return RedirectToAction("Index", "Logins");
            SetViewBags(utilizador);

            return View(lstTriagem);
        }

        public async Task<IActionResult> GroupingSearch(string? search)
        {
            if (search == null) return RedirectToAction(nameof(Index));
            var qryTriagem = _context.Triagem.ToList();
            var qryUtente = _contextUtente.FindBySearch(search);
            var result = from a in qryTriagem join b in qryUtente on a.UtenteID equals b.ID select new { a, b };
            List<Triagem> lstTriagem = new List<Triagem>();
            foreach (var item in result)
            {
                Triagem triagem = item.a;
                triagem.Utente = item.b;
                triagem.UtenteID = item.b.ID;
                lstTriagem.Add(triagem);
            }
            var utilizador = GetObjectFromSession();
            if (utilizador == null) return RedirectToAction("Index", "Logins");
            SetViewBags(utilizador);
            return View(lstTriagem);
        }

        // GET: Triagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Triagem == null)
            {
                return NotFound();
            }

            /*var triagem = await _context.Triagem
                .Include(t => t.Marcacao)
                .Include(t => t.Utente)
                .FirstOrDefaultAsync(m => m.Id == id);*/

            var queryTriagem = from t in _context.Triagem.ToList() select t;
            var queryUtente = from u in _contextUtente.FindAll() select u;
            var result = from a in queryTriagem join b in queryUtente on a.UtenteID equals b.ID where a.Id == id.Value select new { a, b };
            //result = result.Where(qt => qt.a.Id == id.Value);
            Triagem triagem = result.Select(x =>x.a).FirstOrDefault();
            if (triagem == null)
            {
                return NotFound();
            }
            triagem.Utente = result.Select(x => x.b).FirstOrDefault();
            var utilizador = GetObjectFromSession();
            if (utilizador == null) return RedirectToAction("Index", "Logins");
            SetViewBags(utilizador);
            return View(triagem);
        }

        // GET: Triagems/Create
        public IActionResult Create(int? id)
        {
            if (TempData["IdUtente"] == null && id == null) return View();
            var utenteID = TempData["IdUtente"] == null ? id.Value : (int)TempData["IdUtente"];
            var marcacaoID = TempData["IdUtente"] == null ? 1 : (int)TempData["IdMarcacao"];
            var utente = _contextUtente.FindById(utenteID);
            Triagem triagem = new() { Utente = utente, MarcacaoID = marcacaoID };
            var utilizador = GetObjectFromSession();
            if (utilizador == null) return RedirectToAction("Index", "Logins");
            SetViewBags(utilizador);
            return View(triagem);
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
            var utilizador = GetObjectFromSession();
            if (utilizador == null) return RedirectToAction("Index", "Logins");
            SetViewBags(utilizador);
            return View(triagem);
        }

        // GET: Triagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Triagem == null)
            {
                return NotFound();
            }

            var queryTriagem = from t in _context.Triagem.ToList() select t;
            var queryUtente = from u in _contextUtente.FindAll() select u;
            var result = from a in queryTriagem join b in queryUtente on a.UtenteID equals b.ID where a.Id == id.Value select new { a, b };
            //result = result.Where(qt => qt.a.Id == id.Value);
            Triagem triagem = result.Select(x => x.a).FirstOrDefault();
            //triagem.Utente = result.Select(x => x.b).FirstOrDefault();
            if (triagem == null)
            {
                return NotFound();
            }
            triagem.Utente = result.Select(x => x.b).FirstOrDefault();
            var utilizador = GetObjectFromSession();
            if (utilizador == null) return RedirectToAction("Index", "Logins");
            SetViewBags(utilizador);
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
            var utilizador = GetObjectFromSession();
            if (utilizador == null) return RedirectToAction("Index", "Logins");
            SetViewBags(utilizador);
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
            var utilizador = GetObjectFromSession();
            if (utilizador == null) return RedirectToAction("Index", "Logins");
            SetViewBags(utilizador);
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
            var utilizador = GetObjectFromSession();
            if (utilizador == null) return RedirectToAction("Index", "Logins");
            SetViewBags(utilizador);
            return RedirectToAction(nameof(Index));
        }

        private bool TriagemExists(int id)
        {
            return _context.Triagem.Any(e => e.Id == id);
        }

        public Utilizador GetObjectFromSession()
        {
            string serializedObject = HttpContext.Session.GetString("Utilizador");
            return JsonConvert.DeserializeObject<Utilizador>(serializedObject);
        }

        public void SetViewBags(Utilizador utilizador)
        {
            ViewBag.Funcao = utilizador.Funcao;
            ViewBag.UserEsp = utilizador.Especializade;
            ViewBag.UserName = utilizador.Nome;
        }
    }
}

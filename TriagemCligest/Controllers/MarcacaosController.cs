using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TriagemCligest.Data;
using TriagemCligest.Models;
using TriagemCligest.Service;

namespace TriagemCligest.Controllers
{
    public class MarcacaosController : Controller
    {
        private readonly MarcacaoService _context;

        public MarcacaosController(MarcacaoService context)
        {
            _context = context;
        }

        // GET: Marcacaos
        public async Task<IActionResult> Index(string? Pesquisar, int page = 1)
        {
            List<Marcacao> lstMarcacao = new();
            Console.WriteLine("Pesquisar " + Pesquisar);
            if (Pesquisar != null)
            {
                lstMarcacao = _context.FindBySeach(Pesquisar);
            }
            else
            {
                lstMarcacao = _context.FindAll();
            }
            var utilizador = GetObjectFromSession();
            if (utilizador == null) return RedirectToAction("Index", "Logins");

            if (utilizador.Funcao == Models.Enum.Funcao.FUNCIONARIO)
            {
                HttpContext.Session.Remove("Utilizador");
                return RedirectToAction("Index", "Logins");
            }

            const int paginaTamanho = 10;
            if (page < 1) page = 1;
            int recordCount = lstMarcacao.Count();
            var pager = new Pager(recordCount, page, paginaTamanho);
            int recordSkip = (page - 1) * paginaTamanho;
            var data = lstMarcacao.Skip(recordSkip).Take(pager.PaginaTamanho).ToList();
            this.ViewBag.Pager = pager;

            SetViewBags(utilizador);
            return View(data);
        }

        public IActionResult Triagem(int? id)
        {
            
            var marcacao = _context.FindById(id.Value);

            //Console.WriteLine("IdUtente " + marcacao.IDutente);
            //Console.WriteLine("IdFuncionario " + marcacao.IDCentro);
            
            TempData["IdUtente"] = marcacao.IDutente;
            TempData["IdFuncionario"] = marcacao.IDCentro;
            TempData["Especialidade"] = marcacao.Especialidade;
            TempData["IdMarcacao"] = marcacao.ID;
            var utilizador = GetObjectFromSession();
            if (utilizador == null) return RedirectToAction("Index", "Logins");
            SetViewBags(utilizador);
            return RedirectToAction("Create", "Triagems");
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

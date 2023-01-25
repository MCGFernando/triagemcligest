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
        public IActionResult Index()
        {
            return View(_context.FindAll());
        }

        public IActionResult Triagem(int? id)
        {
            
            var marcacao = _context.FindById(id.Value);

            //Console.WriteLine("IdUtente " + marcacao.IDutente);
            //Console.WriteLine("IdFuncionario " + marcacao.IDCentro);

            TempData["IdUtente"] = marcacao.IDutente;
            TempData["IdFuncionario"] = marcacao.IDCentro;
            TempData["Especialidade"] = marcacao.Especialidade;
            
            return RedirectToAction("Create", "Triagems");
        }
    }
}

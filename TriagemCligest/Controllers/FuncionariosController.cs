using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TriagemCligest.Data;
using TriagemCligest.Models;
using TriagemCligest.Service;

namespace TriagemCligest.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly FuncionarioService _context;

        public FuncionariosController(FuncionarioService context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public IActionResult Index()
        {
              return View(_context.FindAll());
        }

        public ActionResult<IEnumerable<Funcionario>> FindBySearch(string search)
        {
            return _context.FindBySearch(search);
        }

        public ActionResult<Funcionario> GetFromID(int? id)
        {
            Console.WriteLine("ID FuncionarioController " + id);
            return Json( _context.FindById(id.Value));
        }


    }
}

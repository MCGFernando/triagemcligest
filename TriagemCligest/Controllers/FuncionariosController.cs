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

        
    }
}

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
    public class OperadorsController : Controller
    {
        private readonly OperadorService _context;

        public OperadorsController(OperadorService context)
        {
            _context = context;
        }

        // GET: Operadors
        public IActionResult Index()
        {
              return View(_context.FindAll());
        }
    }
}

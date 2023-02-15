using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using TriagemCligest.Models;
using TriagemCligest.Service;

namespace TriagemCligest.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _context; 
        private readonly ILogger<HomeController> _logger;

        public LoginController(LoginService context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Utilizador utilizador)
        {
            var user = _context.CheckUserCredentials(utilizador.Nome, utilizador.Senha);
            if (user == null)
            {
                return View(nameof(Index));
            }
            string serializedObject = JsonConvert.SerializeObject(user);
            HttpContext.Session.SetString("Utilizador", serializedObject); 
            Console.WriteLine("Chegou");
            return RedirectToAction("Index", "Home");
        }


    }
}

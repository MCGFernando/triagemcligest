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

        public LoginController(LoginService context)
        {
            _context = context;
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
            return RedirectToAction("Index", "Home");
        }


    }
}

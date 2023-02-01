using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using TriagemCligest.Models;

namespace TriagemCligest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {
            var utilizador = GetObjectFromSession();
            if (utilizador == null) return RedirectToAction("Index", "Logins");
            SetViewBags(utilizador);
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
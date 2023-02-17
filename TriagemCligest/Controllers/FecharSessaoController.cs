using Microsoft.AspNetCore.Mvc;

namespace TriagemCligest.Controllers
{
    public class FecharSessaoController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Remove("Utilizador");
            return RedirectToAction("Index", "Login");
        }
    }
}

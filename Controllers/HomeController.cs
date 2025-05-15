using Microsoft.AspNetCore.Mvc;

namespace SaborDoBrasil.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
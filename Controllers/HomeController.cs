using Microsoft.AspNetCore.Mvc;
using SaborDoBrasil.Data;
using System.Linq;

namespace SaborDoBrasil.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var usuarios = _context.Usuarios.ToList();
            return View(usuarios);
        }
    }
}
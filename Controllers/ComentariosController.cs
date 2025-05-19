using Microsoft.AspNetCore.Mvc;
using SaborDoBrasil.Data;
using SaborDoBrasil.Models;
using System.Linq;

namespace SaborDoBrasil.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly AppDbContext _context;
        public ComentariosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var comentarios = _context.Comentarios.ToList();
            return View(comentarios);
        }
    }
}

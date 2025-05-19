using Microsoft.AspNetCore.Mvc;
using SaborDoBrasil.Data;
using SaborDoBrasil.Models;
using System.Linq;

namespace SaborDoBrasil.Controllers
{
    public class ReacoesUsuariosController : Controller
    {
        private readonly AppDbContext _context;
        public ReacoesUsuariosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var reacoes = _context.ReacoesUsuarios.ToList();
            return View(reacoes);
        }
    }
}

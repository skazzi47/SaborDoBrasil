using Microsoft.AspNetCore.Mvc;
using SaborDoBrasil.Data;
using SaborDoBrasil.Models;
using System.Linq;

namespace SaborDoBrasil.Controllers
{
    public class PublicacoesController : Controller
    {
        private readonly AppDbContext _context;
        public PublicacoesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var publicacoes = _context.Publicacoes.ToList();
            return View(publicacoes);
        }
    }
}

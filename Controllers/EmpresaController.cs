using Microsoft.AspNetCore.Mvc;
using SaborDoBrasil.Data;
using SaborDoBrasil.Models;
using System.Linq;

namespace SaborDoBrasil.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly AppDbContext _context;
        public EmpresaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var empresas = _context.Empresa.ToList();
            return View(empresas);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SaborDoBrasil.Data;
using SaborDoBrasil.Models;
using System.Linq;

namespace SaborDoBrasil.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var usuarios = _context.Usuarios.ToList();
            return View(usuarios);
        }

        [HttpPost]
        [Route("/api/usuarios/cadastrar")]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nome) || string.IsNullOrWhiteSpace(usuario.Email) || string.IsNullOrWhiteSpace(usuario.Senha))
            {
                return BadRequest(new { erro = "Preencha todos os campos." });
            }
            if (_context.Usuarios.Any(u => u.Email == usuario.Email))
            {
                return Conflict(new { erro = "Usuário já cadastrado." });
            }
            // (Opcional) Hash da senha pode ser feito aqui
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Ok(new { sucesso = true });
        }

        [HttpPost]
        [Route("/api/usuarios/login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Email) || string.IsNullOrWhiteSpace(usuario.Senha))
            {
                return BadRequest(new { erro = "Preencha todos os campos." });
            }
            var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email && u.Senha == usuario.Senha);
            if (usuarioDb == null)
            {
                return Unauthorized(new { erro = "Usuário ou senha incorretos." });
            }
            return Ok(new { sucesso = true, nome = usuarioDb.Nome, email = usuarioDb.Email, foto = usuarioDb.Foto });
        }

        [HttpPost]
        [Route("/api/usuarios/atualizar-foto")]
        public IActionResult AtualizarFoto([FromBody] AtualizarFotoRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Email) || string.IsNullOrWhiteSpace(req.Foto))
                return BadRequest(new { erro = "Dados inválidos." });
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == req.Email);
            if (usuario == null)
                return NotFound(new { erro = "Usuário não encontrado." });
            usuario.Foto = req.Foto;
            _context.SaveChanges();
            return Ok(new { sucesso = true });
        }

        public class AtualizarFotoRequest
        {
            public string? Email { get; set; }
            public string? Foto { get; set; }
        }
    }
}

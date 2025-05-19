using Microsoft.EntityFrameworkCore;
using SaborDoBrasil.Models;

namespace SaborDoBrasil.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }
        public DbSet<ReacaoUsuario> ReacoesUsuarios { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ReacaoUsuario>()
                .HasKey(r => new { r.IdUsuarios, r.IdPublicacoes });
        }
    }
}


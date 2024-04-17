using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Dados
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefas> Tarefas { get; set; }
    }
}

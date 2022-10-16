using Microsoft.EntityFrameworkCore;
using SistemaVentaVideojuegos.Models;

namespace SistemaVentaVideojuegos
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Videojuego> Videojuego { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}

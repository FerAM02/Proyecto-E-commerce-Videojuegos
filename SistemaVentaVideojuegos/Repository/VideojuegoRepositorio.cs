using Microsoft.EntityFrameworkCore;
using SistemaVentaVideojuegos.Models;

namespace SistemaVentaVideojuegos.Repository
{
    public class VideojuegoRepositorio
    {
        private readonly AplicationDbContext _context;
        private readonly DbSet<Videojuego> entities;

        public VideojuegoRepositorio(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CrearVideojuego(Videojuego model)
        {
            await _context.Videojuego.AddAsync(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> ActualizarVideojuego(Videojuego model)
        {
            _context.Videojuego.Update(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<Videojuego> ObtenerPorId(int? id)
        {
            return await _context.Videojuego.FindAsync(id);
        }

        public async Task<List<Videojuego>> ObtenerListaVideojuegos()
        {
            return await _context.Videojuego.ToListAsync();
        }

        public async Task<int> EliminarVideojuego(int? id)
        {
            var videojuego = await ObtenerPorId(id);
            _context.Videojuego.Remove(videojuego);
            return await _context.SaveChangesAsync();
        }
    }
}

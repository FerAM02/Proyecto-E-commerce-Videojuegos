using Microsoft.EntityFrameworkCore;
using SistemaVentaVideojuegos.Models;

namespace SistemaVentaVideojuegos.Repository
{
    public class UsuarioRepositorio
    {
        private readonly AplicationDbContext _context;
        private readonly DbSet<Usuario> entities;

        public UsuarioRepositorio(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CrearUsuario(Usuario model)
        {
            await _context.Usuario.AddAsync(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> ActualizarUsario(Usuario model)
        {
            _context.Usuario.Update(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<Usuario> ObtenerPorId(int? id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public async Task<List<Usuario>> ObtenerListaUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<int> EliminarUsuario(int? id)
        {
            var usuario = await ObtenerPorId(id);
            _context.Usuario.Remove(usuario);
            return await _context.SaveChangesAsync();
        }
    }
}

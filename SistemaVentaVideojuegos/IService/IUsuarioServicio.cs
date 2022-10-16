using SistemaVentaVideojuegos.Models;

namespace SistemaVentaVideojuegos.IService
{
    public interface IUsuarioServicio
    {
        Task<ResponseHelper> CrearUsuario(Usuario usuario);
        Task<ResponseHelper> EliminarUsuario(int? id);
        Task<ResponseHelper> ActualizarUsuario(Usuario usuario);
        Task<List<Usuario>> ObtenerUsuarios();
        Task<Usuario> ObtenerPorId(int? id);
    }
}

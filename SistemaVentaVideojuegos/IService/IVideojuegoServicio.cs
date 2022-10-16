using SistemaVentaVideojuegos.Models;

namespace SistemaVentaVideojuegos.IService
{
    public interface IVideojuegoServicio
    {
        Task<ResponseHelper> CrearVideojuego(Videojuego videojuego);
        Task<ResponseHelper> EliminarVideojuego(int? id);
        Task<ResponseHelper> ActualizarVideojuego(Videojuego videojuego);
        Task<List<Videojuego>> ObtenerVideojuegos();
        Task<Videojuego> ObtenerPorId(int? id);
    }
}

using SistemaVentaVideojuegos.IService;
using SistemaVentaVideojuegos.Models;
using SistemaVentaVideojuegos.Repository;
using System.Reflection.Metadata;

namespace SistemaVentaVideojuegos.Service
{
    public class VideojuegoServicio : IVideojuegoServicio
    {
        private readonly VideojuegoRepositorio _videojuegoRepositorio;
        private readonly ILogger<VideojuegoServicio> _logger;

        public VideojuegoServicio(ILogger<VideojuegoServicio> logger, AplicationDbContext context)
        {
            _logger = logger;
            _videojuegoRepositorio = new VideojuegoRepositorio(context);

        }

        public async Task<ResponseHelper> CrearVideojuego(Videojuego videojuego)
        {
            ResponseHelper response = new ResponseHelper();
            try
            {
                var responseVideojuego = await _videojuegoRepositorio.CrearVideojuego(videojuego);
                if (responseVideojuego > 0)
                {
                    response.Success = true;
                    response.Message = "Videojuego generado correctamente";
                }
                else
                {
                    response.Success = false;
                    response.Message = "No se pudo generar el dato";
                    _logger.LogInformation(response.Message);

                }
            }
            catch (Exception a)
            {
                response.Message = "El videojuego no pudo ser creado";
                _logger.LogError(a.Message);
            }
            return response;
        }

        public async Task<ResponseHelper> ActualizarVideojuego(Videojuego videojuego)
        {
            var response = new ResponseHelper();
            try
            {
                //Videojuego videojuego = await _videojuegoRepositorio.ObtenerPorId(model.Id);
                if (await _videojuegoRepositorio.ActualizarVideojuego(videojuego) > 0)
                {
                    response.Success = true;
                    response.Message = "El videojuego ha sido actualizado";
                    _logger.LogInformation(response.Message);
                    return response;
                }
                else
                {
                   response.Success = false;
                    response.Message = "El videojuego no se ha podido actualizar";
                }
            }
            catch (Exception a)
            {
                response.Success=false;
                response.Message = "Error, pongase en contacto con el administrador";
                _logger.LogError (a.Message);
            }
            return response;
        }

        public async Task<ResponseHelper> EliminarVideojuego(int? Id)
        {
            ResponseHelper response = new ResponseHelper();
            try
            {
                if (await _videojuegoRepositorio.EliminarVideojuego(Id) > 0)
                {
                    response.Success = true;
                    response.Message = "Eliminación exitosa";
                    _logger.LogInformation(response.Message);
                }
                else
                {
                    response.Success= false;
                    response.Message = "Eliminación fallida";
                    _logger.LogInformation(response.Message);
                }
            }
            catch (Exception a)
            {
                _logger.LogError(a.Message);
                response.Message = "Error en la operación";
            }
            return response;
        }

        public async Task<List<Videojuego>> ObtenerVideojuegos()
        {
            List<Videojuego> videojuegos = new List<Videojuego>(); try
            {
                videojuegos = await _videojuegoRepositorio.ObtenerListaVideojuegos();

            }
            catch (Exception a)
            {
                _logger.LogError(a.Message);
            }
            return videojuegos;
        }

        public async Task<Videojuego> ObtenerPorId(int? id)
        {
            var videojuego = new Videojuego();
            try
            {
                videojuego = await _videojuegoRepositorio.ObtenerPorId(id);

            }
            catch (Exception a)
            {
                _logger.LogError(a.Message);
            }
            return videojuego;
        }
    }
}

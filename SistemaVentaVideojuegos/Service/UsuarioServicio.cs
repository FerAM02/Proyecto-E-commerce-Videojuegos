using SistemaVentaVideojuegos.IService;
using SistemaVentaVideojuegos.Models;
using SistemaVentaVideojuegos.Repository;

namespace SistemaVentaVideojuegos.Service
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;
        private readonly ILogger<UsuarioServicio> _logger;
        
        public UsuarioServicio(ILogger<UsuarioServicio> logger, AplicationDbContext context)
        {
            _logger = logger;
            _usuarioRepositorio = new UsuarioRepositorio(context);
        }

        public async Task<ResponseHelper> ActualizarUsuario(Usuario usuario)
        {
            var response = new ResponseHelper();
            try
            {
                if (await _usuarioRepositorio.ActualizarUsario(usuario) > 0)
                {
                    response.Success = true;
                    response.Message = "El Usuario ha sido actualizado";
                    _logger.LogInformation(response.Message);
                    return response;
                }
                else
                {
                    response.Success=false;
                    response.Message = "El usuario no ha sido actualizado";
                }
            }
            catch (Exception a)
            {
                response.Success = false;
                response.Message = "Error, contacte al administrador";
                _logger.LogError(a.Message);
            }
            return response;
        }

        public async Task<ResponseHelper> CrearUsuario(Usuario usuario)
        {
            ResponseHelper response = new ResponseHelper();
            try
            {
                var responseUsuario = await _usuarioRepositorio.CrearUsuario(usuario);
                if(responseUsuario > 0)
                {
                    response.Success = true;
                    response.Message = "Usuario creado correctamente";
                }
                else
                {
                    response.Success = false;
                    response.Message = "No se pudo crear el usuario";
                    _logger.LogInformation(response.Message);
                }

            }
            catch (Exception a)
            {
                response.Message = "Error al crear el usuario";
                _logger.LogError(a.Message);
            }
            return response;
        }

        public async Task<ResponseHelper> EliminarUsuario(int? Id)
        {
            ResponseHelper response = new ResponseHelper();
            try
            {
                if (await _usuarioRepositorio.EliminarUsuario(Id) > 0)
                {
                    response.Success = true;
                    response.Message = "Eliminación exitosa";
                    _logger.LogInformation(response.Message);
                }
                else
                {
                    response.Success = false;
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

        public async Task<Usuario> ObtenerPorId(int? Id)
        {
            var usuario = new Usuario();
            try
            {
                usuario = await _usuarioRepositorio.ObtenerPorId(Id);
            }
            catch (Exception a)
            {
                _logger.LogError(a.Message);
            }
            return usuario;
        }

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            List<Usuario> usuario = new List<Usuario>();
            try
            {
                usuario = await _usuarioRepositorio.ObtenerListaUsuario();
            }
            catch (Exception a)
            {
                _logger.LogError(a.Message);
            }
            return usuario;
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVentaVideojuegos.Models;

namespace SistemaVentaVideojuegos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public UsuarioController(AplicationDbContext context)
        {
            _context = context;
        }

        //Lista de usuarios
        [HttpGet]
        [Route("ObtenerListaUsuarios")]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            try
            {
                var listUsuarios = await _context.Usuario.ToListAsync();

                return Ok(listUsuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Devolver usuario por Id
        [HttpGet]
        [Route("ObtenerPorId")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var usuario = await _context.Usuario.FindAsync(id);

                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Crear usuario
        [HttpPost]
        [Route("crearUsuario")]
        public async Task<IActionResult> CrearUsuario([FromBody] Usuario usuario)
        {

            try
            {

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                return Ok(usuario);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // Actualizar usuario
        [HttpPut]
        [Route("actualizarUsario")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if (id != usuario.Id)
                {
                    return BadRequest();
                }

                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario actualizado con exito!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Eliminar usuario
        [HttpDelete]
        [Route("eliminarUsuario")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            try
            {

                var del_usuario = await _context.Usuario.FindAsync(id);

                if (del_usuario == null)
                {
                    return NotFound();
                }

                _context.Usuario.Remove(del_usuario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario eliminado con exito!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVentaVideojuegos.Models;

namespace SistemaVentaVideojuegos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideojuegoController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public VideojuegoController(AplicationDbContext context)
        {
            _context = context;
        }

        //Lista de videojuegos
        [HttpGet]
        [Route("ObtenerListaVideojuegos")]
        public async Task<IActionResult> ObtenerVideojuegos()
        {
            try
            {
                var listVideojuegos = await _context.Videojuego.ToListAsync();

                return Ok(listVideojuegos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Devolver videojuego por Id
        [HttpGet]
        [Route("ObtenerPorId")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                var videojuego = await _context.Videojuego.FindAsync(id);

                if(videojuego == null)
                {
                    return NotFound();
                }
                return Ok(videojuego);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Crear videojuego
        [HttpPost]
        [Route("crearVideojuego")]
        public async Task<IActionResult> CrearVideojuego([FromBody] Videojuego videojuego)
        {

            try
            {

                _context.Add(videojuego);
                await _context.SaveChangesAsync();

                return Ok(videojuego);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // Actualizar videojuego
        [HttpPut]
        [Route("actualizarVideojuego")]
        public async Task<IActionResult> ActualizarVideojuego(int id, [FromBody] Videojuego videojuego)
        {
            try
            {
                if (id != videojuego.Id)
                {
                    return BadRequest();
                }

                _context.Update(videojuego);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Videojuego actualizado con exito!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Eliminar videojuego
        [HttpDelete]
        [Route("eliminarVideojuego")]
        public async Task<IActionResult> EliminarVideojuego(int id)
        {
            try
            {

                var del_videojuego = await _context.Videojuego.FindAsync(id);

                if (del_videojuego == null)
                {
                    return NotFound();
                }

                _context.Videojuego.Remove(del_videojuego);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Videojuego eliminado con exito!" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


    }
}

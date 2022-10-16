using System.ComponentModel.DataAnnotations;

namespace SistemaVentaVideojuegos.Models
{
    public class Videojuego
    {
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        public string? Genero { get; set; }
        public string? Plataforma { get; set; }
        [Required]
        public int Precio { get; set; }

    }
}

using Microsoft.Build.Framework;

namespace SistemaVentaVideojuegos.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string? Correo { get; set; }
        [Required]
        public string? Contraseña { get; set; }
        [Required]
        public string? NombreUsuario { get; set; }



    }
}

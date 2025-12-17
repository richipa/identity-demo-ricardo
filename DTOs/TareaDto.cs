using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.DTOs
{
    public class TareaDto
    {
        // id de la tarea para editar o borrar
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [MaxLength(100, ErrorMessage = "El título no puede superar los 100 caracteres")]
        public string? Titulo { get; set; }

        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public string? Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaCompletada { get; set; }
    }
}

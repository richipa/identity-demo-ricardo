using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace IdentityDemo.Models
{
    [Table("Tarea")]
    public class Tarea
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }


        [Column("titulo")]
        public string? Titulo { get; set; }


        [Column("descripcion")]
        public string? Descripcion { get; set; }


        [Column("estado")]
        public string? Estado { get; set; }


        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }


        [Column("fecha_completada")]
        public DateTime? FechaCompletada { get; set; }


        [Column("user_id")]
        public string? UserId { get; set; }
    }
}

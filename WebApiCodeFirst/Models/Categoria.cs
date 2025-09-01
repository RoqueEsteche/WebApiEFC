using System.ComponentModel.DataAnnotations;

namespace WebApiCodeFirst.Models
{
    //Es una entidad
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}
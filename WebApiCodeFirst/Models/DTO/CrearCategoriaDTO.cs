using System.ComponentModel.DataAnnotations;

namespace WebApiCodeFirst.Models.DTO
{
    public class CrearCategoriaDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El número máximo de caracteres es de 100!")]
        public string Nombre { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Sdk;

namespace Web_24BM.Models
{
    public class Curriculum
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(50, ErrorMessage = "El campo no debe superar el limite")]
        public string Nombre { get; set; }

        [StringLength(50, ErrorMessage = "El campo no debe superar el limite")]
        public string Apellidos { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "El campo debe tener un formato de correo valido")]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "La dirección es requerida")]
        public string Dirrecion { get; set; }
        public string Objetivo { get; set; }
        [NotMapped]
        public IFormFile? Foto { get; set; }
        public string DatosLaboral { get; set; }
        public string NombreFoto { get; set; }
        [StringLength(18, ErrorMessage = "La CURP debe tener exactamente 18 caracteres.")]
        public string Curp { get; set; }
  
    }
}

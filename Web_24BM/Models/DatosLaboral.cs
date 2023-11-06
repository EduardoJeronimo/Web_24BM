using System.ComponentModel.DataAnnotations;

namespace Web_24BM.Models
{
    public class DatoLaboral
    {
        [Key]
        public int ID { get; set; }
        public string Puesto { get; set; }
        public string Empresa { get; set; }
        public string Contacto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Examen_06.Models
{
    public class AlumnoModel
    {
        public int AlumnoID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [EmailAddress]
        public string CorreoElectronico { get; set; }
    }
}

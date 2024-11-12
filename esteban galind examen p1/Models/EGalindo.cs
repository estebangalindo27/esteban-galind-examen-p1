using System.ComponentModel.DataAnnotations;

namespace esteban_galind_examen_p1.Models
{
    public class EGalindo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public String Nombre { get; set; }

        [Range(0, 100000)]
        public double Salario { get; set; }
        [Range(0, 80)]
        public int Edad { get; set; }

        [Required]
        public bool Activo { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }


        public int CelularId { get; set; }
        public Celular Celular { get; set; }

    }
}

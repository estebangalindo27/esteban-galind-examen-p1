using System.ComponentModel.DataAnnotations;

namespace esteban_galind_examen_p1.Models
{
    public class Celular
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String Modelo { get; set; }

        [Range(2000, 2050)]
        public int Año { get; set; }

        [Required]
        [Range(0.01, 10000.00)]
        public double Precio { get; set; }

        public EGalindo EGalindo { get; set; }
    }
}


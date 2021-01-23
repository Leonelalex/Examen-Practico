using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Examen_Practico.Models
{
    public class Detalle
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int facturaId { get; set; }
        public int productoId { get; set; }
        public int cantidad { get; set; }
    }
}

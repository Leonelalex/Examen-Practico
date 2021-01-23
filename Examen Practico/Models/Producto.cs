using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Examen_Practico.Models
{
    public class Producto
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string nombre { get; set; }
        public float precio { get; set; }
    }
}

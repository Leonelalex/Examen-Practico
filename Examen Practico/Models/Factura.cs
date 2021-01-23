using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Examen_Practico.Models
{
    public class Factura
    {
        [Key]
        public int id { get; set; }

        [Required]
        public DateTime fecha { get; set; }
        public string clienteNit { get; set; }
        public string clienteNombre { get; set; }
        public int total { get; set; }

    }
}

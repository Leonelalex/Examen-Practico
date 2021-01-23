using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_Practico.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Detalle> Detalles { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}

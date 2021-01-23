using Examen_Practico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_Practico.Controllers
{
    public class FacturasController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Factura factura { get; set; }

        public FacturasController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Insert(int? id)
        {
            factura = new Factura();
            if(id == null)
            {
                return View(factura);
            }
            factura = _db.Facturas.FirstOrDefault(x => x.id == id);
            if(factura == null)
            {
                return NotFound();
            }
            return View(factura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert()
        {
            if (ModelState.IsValid)
            {
                if(factura.id == 0)
                {
                    _db.Facturas.Add(factura);
                } 
                else
                {
                    _db.Facturas.Update(factura);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(factura);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Facturas.ToListAsync() });
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(int id)
        {
   
            string detQuery = "select fac.id as factuaId, fac.clienteNombre, fac.clienteNit, fac.fecha, fac.total, prod.*, det.cantidad from Detalles det " +
                                "join Facturas fac on det.facturaId = fac.id join Productos prod on det.productoId = prod.id " +
                                "where det.facturaId = {0}";
            //var detalle = _db.Database.sql(detQuery, id);

            return View();

            //return Json(new { data = await _db.Database.ExecuteSqlRawAsync(detQuery, id) });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var facturaFromDb = await _db.Facturas.FirstOrDefaultAsync(x => x.id == id);
            if (facturaFromDb == null)
            {
                return Json(new { succes = false, message = "Error al eliminar factura" });
            }
            _db.Facturas.Remove(facturaFromDb);
            await _db.SaveChangesAsync();
            return Json(new { succes = true, message = "Factura eliminada exitosamente"});
        }
    }
}

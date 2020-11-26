using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VuelaLibreProject.Models.DB;
using VuelaLibreProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace VuelaLibreProject.Controllers
{
    public class FligthsController : Controller
    {
        private VuelaLibreContext _context;

        public FligthsController (VuelaLibreContext context)
        {

            this._context = context;

        }

       
        
      
        public IActionResult ListaVuelos()
        {
            ViewBag.Vuelos = _context.vuelos.ToList();

            var vuelos = _context.vuelos.ToList();

            ViewBag.provincia = _context.ListProvincias.ToList();
            ViewBag.aerolinea = _context.ListAerolineas.ToList();
            

            return View(vuelos);
        }



        public ActionResult CrearVuelo() // GET
        {

            ViewBag.Provincias = _context.ListProvincias.ToList();
            ViewBag.Aerolineas = _context.ListAerolineas.ToList();
            ViewBag.fechaVuelo = DateTime.Now;


            return View("CrearVuelo", new Vuelos());

        }


        [HttpPost]
        public ActionResult CrearVuelo(Vuelos vuel, DateTime fechaVuelo) // POST
        {


            var now = DateTime.Now;
            int fechaResultado = DateTime.Compare(fechaVuelo, now);
            if (fechaResultado < 0)
                ModelState.AddModelError("FechaVuelo", "La fecha de salida debe ser mayor a la actual");


            if (true)
            {
                _context.vuelos.Add(vuel);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Provincias = _context.ListProvincias.ToList();
            ViewBag.Aerolineas = _context.ListAerolineas.ToList();
            return View("CrearVuelo",vuel);

        }


    }
}

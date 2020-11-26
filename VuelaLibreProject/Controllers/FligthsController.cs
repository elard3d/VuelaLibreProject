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

            ViewBag.departamento= _context.ListDepartamento.ToList();
            ViewBag.aerolinea = _context.ListAerolineas.ToList();
            

            return View(vuelos);
        }



        public ActionResult CrearVuelo() // GET
        {

            ViewBag.Departamentos = _context.ListDepartamento.ToList();
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
           
            return View("CrearVuelo",vuel);

        }

        [HttpGet]
        public ActionResult ComprarVuelo(int id) {

            var vuel = _context.vuelos.Where(o => o.idVuelo == id).FirstOrDefault();

            ViewBag.Departamentos= _context.ListDepartamento.ToList();
            ViewBag.Aerolineas = _context.ListAerolineas.ToList();


            return View(vuel);
        
        }


        
        [HttpPost]
        public ActionResult ComprarVuelos(Vuelos vuelos, int id, string dni, string nombres, string apellidos, int numAsiento) {

            var ticket = new Pasaje();

            var vuel = _context.vuelos.Where(o => o.idVuelo == id).FirstOrDefault();


            return View();
        
        }


    }
}

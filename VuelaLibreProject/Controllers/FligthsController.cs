using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VuelaLibreProject.Models.DB;
using VuelaLibreProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace VuelaLibreProject.Controllers
{
    public class FligthsController : Controller
    {
        private VuelaLibreContext _context;
        private readonly IConfiguration configuration;

        public FligthsController (VuelaLibreContext context, IConfiguration configuration)
        {

            this._context = context;
            this.configuration = configuration;

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
        public ActionResult ComprarVuelos(int id) {

            var vuel = _context.vuelos.Where(o => o.idVuelo == id).FirstOrDefault();

            ViewBag.Departamentos= _context.ListDepartamento.ToList();
            ViewBag.Aerolineas = _context.ListAerolineas.ToList();


            return View(vuel);
        
        }



        [HttpPost]
        public ActionResult ComprarVuelos(Vuelos vuelos, int id, string dni, string nombres, string apellidos, int numAsientos ) {

            var pasaje = new Pasaje();
            var vuel = _context.vuelos.Where(o => o.idVuelo == id).FirstOrDefault();
            var nombreOrigen = _context.ListDepartamento.Where(o => o.nombreDepartamentos == vuel.departamentoOrigen.nombreDepartamentos).FirstOrDefault();
            var nombreDestino = _context.ListDepartamento.Where(o => o.nombreDepartamentos == vuel.departamentoDestino.nombreDepartamentos).FirstOrDefault();
            


            pasaje.dni = dni;
            pasaje.nombres = nombres;
            pasaje.apellidos = apellidos;
            pasaje.numAsiento = numAsientos;
            pasaje.origen = nombreOrigen.nombreDepartamentos;
            pasaje.destino = nombreDestino.nombreDepartamentos;
            pasaje.fechaCompra = DateTime.Now;
            pasaje.precio = vuel.precioVuelo;
            pasaje.fechaVuelo = vuel.fechaHoraVuelo;

            _context.ListPasaje.Add(pasaje);
            _context.SaveChanges();

         
            return View("index", "home");


        }


    }
}

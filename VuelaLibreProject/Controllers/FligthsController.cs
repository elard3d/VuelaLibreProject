using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using VuelaLibreProject.Models;
using VuelaLibreProject.Models.DB;

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

        public Usuario LoggerUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = _context.usuarios.Where(o => o.correoUsuario == claim.Value).FirstOrDefault();
            return user;
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
        public ActionResult ComprarVuelos(int id, int numeroPasajes = 1) {

            var vuel = _context.vuelos.Where(o => o.idVuelo == id).FirstOrDefault();

            ViewBag.Departamentos= _context.ListDepartamento.ToList();
            ViewBag.Aerolineas = _context.ListAerolineas.ToList();

            ViewBag.NumeroPajases = numeroPasajes;


            return View(vuel);
        
        }


        private int GetLasId()
        {
            try {
                return _context.ListPasaje.OrderByDescending(o => o.idPasaje).FirstOrDefault().idPasaje;
            } catch(Exception e){
                return 1;
            }
        }

     
        [HttpPost]
        public ActionResult ComprarVuelos( Pasaje []pasajes, int idVuelo) {

            foreach (var pasaje in pasajes) {

                pasaje.idPasaje = GetLasId() + 1;
                pasaje.idUsuario = LoggerUser().idUsuario;
                pasaje.fechaCompra = DateTime.Now;
                pasaje.idVuelo = idVuelo;
                _context.ListPasaje.Add(pasaje);
                _context.SaveChanges();

                var ticketVuelo = new TicketVuelo();
                int idPasaje = pasaje.idPasaje;

                ticketVuelo.idPasaje = idPasaje;
                ticketVuelo.idVuelo = idVuelo;

                _context.ListTicketVuelo.Add(ticketVuelo);
                _context.SaveChanges();

            }
                     
            return View("index", "home");


        }


    }
}

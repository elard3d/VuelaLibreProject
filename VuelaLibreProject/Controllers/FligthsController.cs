using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VuelaLibreProject.Models.DB;
using VuelaLibreProject.Models;

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

            return View();
        }

        
    }
}

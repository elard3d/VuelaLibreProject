using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VuelaLibreProject.Models;
using VuelaLibreProject.Models.DB;

namespace VuelaLibreProject.Controllers
{
    public class HomeController : Controller
    {

        private VuelaLibreContext _context;
        private readonly IConfiguration configuration;

        private readonly ILogger<HomeController> _logger;

        public HomeController(VuelaLibreContext context, IConfiguration configuration)
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

        public IActionResult Index()
        {
            ViewBag.Departamentos = _context.ListDepartamento.ToList();
            ViewBag.Aerolineas = _context.ListAerolineas.ToList();
            ViewBag.fechaVuelo = DateTime.Now;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

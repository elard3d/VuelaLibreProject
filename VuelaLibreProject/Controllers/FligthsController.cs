using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VuelaLibreProject.Models.DB;
using VuelaLibreProject.Models;
using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace VuelaLibreProject.Controllers
{
    public class FligthsController : Controller
    {
        private VuelaLibreContext _context;
        private readonly IConfiguration configuration;

        public FligthsController (VuelaLibreContext context, IConfiguration configuration)
        {
            this.configuration = configuration;
            this._context = context;

        }
        public IActionResult Index()
        {
            ViewBag.Vuelos = _context.vuelos.ToList();

            return View();
        }
        //REGISTRO DE USUARIO
        
        //LOGIN Y LOGOUT DE USUARIO
      




        //FUNCIONES PARA EL USUARIO
        private string CreateHash(string input)
        {
            var sha = SHA256.Create();
            input += configuration.GetValue<string>("Token");
            var hash = sha.ComputeHash(Encoding.Default.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
        public Usuario LoggerUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = _context.usuarios.Where(o => o.correoUsuario == claim.Value).FirstOrDefault();
            return user;
        }

    }
}

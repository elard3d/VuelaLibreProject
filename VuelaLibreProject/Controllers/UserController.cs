using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VuelaLibreProject.Models.DB;

using VuelaLibreProject.Models;

namespace VuelaLibreProject.Controllers
{
    public class UserController : Controller { 

        
    private readonly VuelaLibreContext _context;
        
    private readonly IConfiguration configuration;

         public UserController(VuelaLibreContext context, IConfiguration configuration)
        {
        _context = context;
        this.configuration = configuration;
            }


        public Usuario LoggerUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = _context.usuarios.Where(o => o.correoUsuario == claim.Value).FirstOrDefault();
            return user;
        }

        public IActionResult Perfil()
        {
            ViewBag.Usuarios = _context.usuarios.ToList();

            return View();
        }
    }
}

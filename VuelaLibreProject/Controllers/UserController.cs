using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VuelaLibreProject.Models.DB;

using VuelaLibreProject.Models;
using Microsoft.EntityFrameworkCore;

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
            ViewBag.Usuarios = _context.usuarios.Where(o=>o.idUsuario == LoggerUser().idUsuario).FirstOrDefault();

            ViewBag.Pasajes = _context.ListPasaje.Where(o => o.idUsuario == LoggerUser().idUsuario).Include(o=>o.vuelo).ThenInclude(o=>o.departamentoOrigen).Include(o=>o.vuelo).ThenInclude(o=>o.departamentoDestino).ToList();
            

            ViewBag.Departamentos = _context.ListDepartamento.ToList();
            ViewBag.Aerolineas = _context.ListAerolineas.ToList();

            ViewBag.Vuelos = _context.vuelos.Include(o=>o.departamentoOrigen).Include(o=>o.departamentoDestino).ToList();
            
            
            ViewBag.TicketVuelo= _context.ListTicketVuelo.ToList();


            return View();
        }
    }
}

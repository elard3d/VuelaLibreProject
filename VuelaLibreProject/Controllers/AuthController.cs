using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VuelaLibreProject.Models;
using VuelaLibreProject.Models.DB;

namespace VuelaLibreProject.Controllers
{
    public class AuthController : Controller
    {
        private VuelaLibreContext context;
        private readonly IConfiguration configuration;

        public AuthController(VuelaLibreContext _context, IConfiguration _configuration)
        {

            this.context = _context;
            this.configuration = _configuration;

        }

        //REGISTER USUARIO
        [HttpGet]
        public ActionResult Register() // GET
        {
            return View("Register", new Usuario());

        }

        [HttpPost]
        public ActionResult Register(Usuario usuario, string contraseñaUsuario, string correo, string verContraseñaUsuario) // POST
        {

            var correos = context.usuarios.ToList();
            foreach (var item in correos)
            {
                if (item.correoUsuario == correo)
                    ModelState.AddModelError("Correo", "El correo ya existe, ingrese otro correo");
            }

            if (ModelState.IsValid)
            {
                usuario.contraseñaUsuario = CreateHash(contraseñaUsuario);
                usuario.verContraseñaUsuario = CreateHash(verContraseñaUsuario);
                context.usuarios.Add(usuario);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View("Register", usuario);
        }

        //LOGIN USUARIO
        public IActionResult Login(Usuario account, string correoUsuario, string contraseñaUsuario)
        {
            var user = context.usuarios.Where(o => o.correoUsuario == correoUsuario && o.contraseñaUsuario == CreateHash(contraseñaUsuario))
                .FirstOrDefault();

            if (user != null)
            {
                ViewBag.iduser = user.idUsuario;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, correoUsuario)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(claimsPrincipal);
                ViewBag.userid = user.idUsuario;

                return RedirectToAction("Index");
            }
            //ModelState.AddModelError("Login", "Usuario o contraseña incorrectos.");
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }
        private string CreateHash(string input)
        {
            var sha = SHA256.Create();
            input += configuration.GetValue<string>("Token");
            var hash = sha.ComputeHash(Encoding.Default.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
    }
}

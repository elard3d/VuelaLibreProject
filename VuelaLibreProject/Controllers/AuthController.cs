﻿using System;
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

        public string LoggedUser()
        {

            var claims = HttpContext.User.Claims.FirstOrDefault();
            var user = context.usuarios.Where(o => o.correoUsuario == claims.Value).FirstOrDefault();

            return "el usuario logueado es " + user.nombreUsuario;

        }


        public string Index(string input)
        {
            return CreateHash(input);
        }

        public IActionResult Login(string email, string password)
        {

            var user = context.usuarios
                .Where(o => o.correoUsuario== email && o.contraseñaUsuario == CreateHash(password))
                .FirstOrDefault();

            if (user != null)
            {

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, email)
                };


                var clainmsIdentity = new ClaimsIdentity(claims, "Login");
                var clainmsPrincipal = new ClaimsPrincipal(clainmsIdentity);

                HttpContext.SignInAsync(clainmsPrincipal);

                return RedirectToAction("Index", "Ejercicios");

            }


            return View();
        }


        [HttpGet]
        public IActionResult Logout()
        {

            HttpContext.SignOutAsync();
            return RedirectToAction("Login");

        }

        private string CreateHash(String input)
        {

            var sha = SHA256.Create();
            input = input + configuration.GetValue<string>("Token");
            var hash = sha.ComputeHash(Encoding.Default.GetBytes(input));

            return Convert.ToBase64String(hash);

        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string email, string password)
        {
            var user = new Usuario();

            user.correoUsuario = email;

            user.contraseñaUsuario = CreateHash(password);

            context.usuarios.Add(user);

            context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

    }
}
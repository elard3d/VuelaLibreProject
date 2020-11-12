using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public string correoUsuario { get; set; }
        public string contraseñaUsuario { get; set; }
        public string verContraseñaUsuario { get; set; }
    }
}

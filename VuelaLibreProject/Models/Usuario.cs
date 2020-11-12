using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido.")]
        [MinLength(2)]
        [RegularExpression(@"[a-zA-Z]+")]
        public string nombreUsuario { get; set; }
        [Required(ErrorMessage = "El campo apellido es requerido.")]
        [MinLength(2)]
        [RegularExpression(@"[a-zA-Z]+")]
        public string apellidoUsuario { get; set; }
        [Required(ErrorMessage = "El campo correo es requerido.")]
        [EmailAddress]
        public string correoUsuario { get; set; }
        [Required(ErrorMessage = "El campo contraseña como mínimo debe contener al menos 6 caracteres.")]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string contraseñaUsuario { get; set; }
        [Required(ErrorMessage = "El campo Confirmar contraseña es obligatorio.")]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("contraseñaUsuario", ErrorMessage = "Las contraseñas no coinciden.")]
        public string verContraseñaUsuario { get; set; }
    }
}

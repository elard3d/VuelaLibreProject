using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models
{
    public class Pasaje
    {
        public int idPasaje { get; set; }
        public int idUsuario { get; set; }

        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int numAsiento{ get; set; }

        public Usuario usuario { get; set; }
    }
}

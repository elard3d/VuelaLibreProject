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

        public string origen { get; set; }
        public string destino { get; set; }
        public DateTime fechaCompra { get; set; }
        public decimal precio { get; set; }
        public DateTime fechaVuelo { get; set; }


        public Usuario usuario { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models
{
    public class Vuelos
    {
        public int idVuelo { get; set; }
        public string salida { get; set; }
        public string destino { get; set; }
        public string tiempoVuelo { get; set; }
        public string precioVuelo { get; set; }
        public string fechaHoraVuelo { get; set; }
        public int asientos{ get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models
{
    public class Vuelos
    {
        public int idVuelo { get; set; }
        public int idProvinciaOrigen{ get; set; }
        public int idProvinciaDestino { get; set; }
        public string tiempoVuelo { get; set; }
        public decimal precioVuelo { get; set; }
        public DateTime fechaHoraVuelo { get; set; }
        public int asientos{ get; set; }
        public int idAerolinea { get; set; }

        public Provincias provinciaOrigen { get; set; }
        public Provincias provinciaDestino { get; set; }
        public Aerolineas aerolineas { get; set; }


    }
}

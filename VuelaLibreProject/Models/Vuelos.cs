using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models
{
    public class Vuelos
    {
        public int idVuelo { get; set; }
        public int idDepartamentoOrigen { get; set; }
        public int idDepartamentoDestino { get; set; }
        public string tiempoVuelo { get; set; }
        public decimal precioVuelo { get; set; }
        public DateTime fechaHoraVuelo { get; set; }
        public int asientos{ get; set; }
        public int idAerolinea { get; set; }

        public Departamentos departamentoOrigen { get; set; }
        public Departamentos departamentoDestino { get; set; }
        public Aerolineas aerolineas { get; set; }
        //public TicketVuelo ticketVuelo { get; set; }


    }
}

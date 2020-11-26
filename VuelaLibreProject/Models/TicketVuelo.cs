using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models
{
    public class TicketVuelo
    {
        public int idTicketVuelo { get; set; }

        public int idPasaje { get; set; }
        public int idVuelo { get; set; }

        //public Vuelos vuelo { get; set; }
        //public Pasaje pasaje { get; set; }
    }
}

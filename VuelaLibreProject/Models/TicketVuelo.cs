using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models
{
    public class TicketVuelo
    {
        public int idTicketVuelo { get; set; }
        public int idTicket { get; set; }
        public int idVuelo { get; set; }

        public Vuelos vuelos { get; set; }
        public Pasaje tickets { get; set; }
    }
}

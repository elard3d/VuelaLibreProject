using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models
{
    public class Tickets
    {
        public int idTicket { get; set; }
        public int idUsuario { get; set; }

        public Usuario usuario { get; set; }
    }
}

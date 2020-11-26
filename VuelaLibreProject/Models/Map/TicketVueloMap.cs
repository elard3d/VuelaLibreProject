using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models.Map
{
    public class TicketVueloMap : IEntityTypeConfiguration<TicketVuelo>
    {
        public void Configure(EntityTypeBuilder<TicketVuelo> builder)
        {
            builder.ToTable("TicketVuelo");
            builder.HasKey(o => o.idTicketVuelo);

            //builder.HasOne(o => o.vuelos).WithMany().HasForeignKey(o => o.idVuelo);
            //builder.HasOne(o => o.pasajes).WithMany().HasForeignKey(o => o.idPasaje);
        }
    }
}

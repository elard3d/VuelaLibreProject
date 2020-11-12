using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models.Map
{
    public class TicketsMap : IEntityTypeConfiguration<Tickets>
    {
        public void Configure(EntityTypeBuilder<Tickets> builder)
        {
            builder.ToTable("Tickets");

            builder.HasKey(o => o.idTicket);

            builder.HasOne(o => o.usuario).WithMany().HasForeignKey(o => o.idUsuario);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models.Map
{
    public class VuelosMap : IEntityTypeConfiguration<Vuelos>
    {
        public void Configure(EntityTypeBuilder<Vuelos> builder)
        {
            builder.ToTable("Vuelos");
            builder.HasKey(o => o.idVuelo);
        }
    }
}

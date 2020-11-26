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

            builder.HasOne(o => o.aerolineas).WithMany().HasForeignKey(o => o.idAerolinea);
            builder.HasOne(o => o.departamentoOrigen).WithMany().HasForeignKey(o=>o.idDepartamentoOrigen);
            builder.HasOne(o => o.departamentoDestino).WithMany().HasForeignKey(o=>o.idDepartamentoDestino);
            
            
           
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models.Map
{
    public class PasajeMap : IEntityTypeConfiguration<Pasaje>
    {
        public void Configure(EntityTypeBuilder<Pasaje> builder)
        {
            builder.ToTable("Pasaje");

            builder.HasKey(o => o.idPasaje);

            builder.HasOne(o => o.usuario).WithMany().HasForeignKey(o => o.idUsuario);
            builder.HasOne(o => o.vuelo).WithMany().HasForeignKey(o => o.idVuelo);
        }
    }
}

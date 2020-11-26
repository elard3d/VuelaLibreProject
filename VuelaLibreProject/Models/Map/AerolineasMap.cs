using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models.Map
{
    public class AerolineasMap : IEntityTypeConfiguration<Aerolineas>
    {
        public void Configure(EntityTypeBuilder<Aerolineas> builder)
        {
            builder.ToTable("Aerolineas");
            builder.HasKey(o => o.idAero);
        }
    }
}

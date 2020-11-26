using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models.Map
{
    public class ProvinciasMap : IEntityTypeConfiguration<Provincias>
    {
        public void Configure(EntityTypeBuilder<Provincias> builder)
        {
            builder.ToTable("Provincias");
            builder.HasKey(o => o.idProvincia);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VuelaLibreProject.Models.Map
{
    public class DepartamentosMap : IEntityTypeConfiguration<Departamentos>
    {
        public void Configure(EntityTypeBuilder<Departamentos> builder)
        {
            builder.ToTable("Departamentos");
            builder.HasKey(o => o.idDepartamentos);
        }
    }
}

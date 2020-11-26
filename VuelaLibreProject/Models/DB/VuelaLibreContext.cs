﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VuelaLibreProject.Models.Map;

namespace VuelaLibreProject.Models.DB
{
    public class VuelaLibreContext : DbContext
    {
        public VuelaLibreContext(DbContextOptions<VuelaLibreContext> options) : base(options) { }

        public DbSet<Vuelos> vuelos { get; set; }

        public virtual DbSet<Usuario> usuarios { get; set; }

        public DbSet<Departamentos> ListDepartamento { get; set; }
        public DbSet<Aerolineas> ListAerolineas { get; set; }
        public DbSet<Pasaje> ListTicket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new VuelosMap());
            modelBuilder.ApplyConfiguration(new DepartamentosMap());
            modelBuilder.ApplyConfiguration(new AerolineasMap());
            modelBuilder.ApplyConfiguration(new PasajeMap());

        }
    }
}

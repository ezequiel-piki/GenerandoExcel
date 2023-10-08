
using GenerandoExcel.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GenerandoExcel
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Persona>()
                .HasData(new List<Persona>
                {
                    new Persona {Id=1,Nombre="Ezequiel"},
                    new Persona {Id=2,Nombre="Georgina"},
                    new Persona {Id=3,Nombre="Francisco"}

                });
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }
        public DbSet<Persona> Personas { get; set; }
    }
}

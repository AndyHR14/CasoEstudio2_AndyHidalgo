using EnviosAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EnviosAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Envios> Envios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Envios>(entity =>
            {

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Destinatario)
                .IsRequired()                   
                .HasMaxLength(150);             

            entity.Property(e => e.Direccion)
                .IsRequired()                   
                .HasMaxLength(250);             

            entity.Property(e => e.Peso)
                .IsRequired();

            entity.Property(e => e.Distancia)
                .IsRequired();

            entity.Property(e => e.Costo)
                .IsRequired()
                .HasDefaultValue(0.0);          

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20)
                .HasDefaultValue(EnviosState.Pendiente);

            entity.Property(e => e.Urgencia)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20)
                .HasDefaultValue(UrgenciaEnvio.Normal);
            });
        }
    }
}

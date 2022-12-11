using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using BlazorApp1.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;

namespace BlazorApp1.Server.Modelos;

public partial class EjempDbContext : DbContext
{
    public EjempDbContext()
    {
    }

    public EjempDbContext(DbContextOptions<EjempDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuario { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("SQL"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        Debug.WriteLine("Hola Mundo");
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Apellido)
            .HasMaxLength(500)
            .IsUnicode(false);
            entity.Property(e => e.Email)
            .HasMaxLength(500)
            .IsUnicode(false);
            entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            entity.Property(e => e.FechaBaja).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
            .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

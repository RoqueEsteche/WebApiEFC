using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApiDatabaseFirst.Models;

namespace WebApiDatabaseFirst.Data;

public partial class UninorteDbContext : DbContext
{
    public UninorteDbContext()
    {
    }

    public UninorteDbContext(DbContextOptions<UninorteDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.ToTable("alumno");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Nombres)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.NroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nro_documento");
        });
    }
}
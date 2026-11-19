using System;
using System.Collections.Generic;
using DSWI_T1_01.Models;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_01.Data;

public partial class LibreriaBdContext : DbContext
{
    public LibreriaBdContext()
    {
    }

    public LibreriaBdContext(DbContextOptions<LibreriaBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autore> Autores { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autore>(entity =>
        {
            entity.HasKey(e => e.AutorId).HasName("PK__Autores__F58AE9098E8D129D");

            entity.Property(e => e.AutorId).HasColumnName("AutorID");
            entity.Property(e => e.Nacionalidad).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.LibroId).HasName("PK__Libros__35A1EC8D944D1E3A");

            entity.Property(e => e.LibroId).HasColumnName("LibroID");
            entity.Property(e => e.AutorId).HasColumnName("AutorID");
            entity.Property(e => e.Genero).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .HasColumnName("ISBN");
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.Autor).WithMany(p => p.Libros)
                .HasForeignKey(d => d.AutorId)
                .HasConstraintName("FK__Libros__AutorID__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

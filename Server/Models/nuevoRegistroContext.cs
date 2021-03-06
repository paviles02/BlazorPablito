using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorPablito.Server.Models
{
    public partial class nuevoRegistroContext : DbContext
    {
        public nuevoRegistroContext()
        {
        }

        public nuevoRegistroContext(DbContextOptions<nuevoRegistroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<DireccionEstudiante> DireccionEstudiante { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Facultad> Facultad { get; set; }
        public virtual DbSet<Grado> Grado { get; set; }
        public virtual DbSet<Maestro> Maestro { get; set; }
        public virtual DbSet<Seccion> Seccion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DEVELOPER-HP; DataBase =nuevoRegistro; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso);

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdMaestro).HasColumnName("idMaestro");

                entity.Property(e => e.NombreCurso)
                    .HasColumnName("nombreCurso")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMaestroNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.IdMaestro)
                    .HasConstraintName("FK_Curso_Maestro");
            });

            modelBuilder.Entity<DireccionEstudiante>(entity =>
            {
                entity.HasKey(e => e.IdDireccionEstudiante);

                entity.Property(e => e.IdDireccionEstudiante)
                    .HasColumnName("idDireccionEstudiante")
                    .ValueGeneratedNever();

                entity.Property(e => e.Direccion1)
                    .HasColumnName("direccion1")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion2)
                    .HasColumnName("direccion2")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDireccionEstudianteNavigation)
                    .WithOne(p => p.DireccionEstudiante)
                    .HasForeignKey<DireccionEstudiante>(d => d.IdDireccionEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DireccionEstudiante_Estudiante");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante);

                entity.Property(e => e.IdEstudiante).HasColumnName("idEstudiante");

                entity.Property(e => e.Altura)
                    .HasColumnName("altura")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.IdFacultad).HasColumnName("idFacultad");

                entity.Property(e => e.IdGrado).HasColumnName("idGrado");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Peso)
                    .HasColumnName("peso")
                    .HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.IdFacultadNavigation)
                    .WithMany(p => p.Estudiante)
                    .HasForeignKey(d => d.IdFacultad)
                    .HasConstraintName("FK_Estudiante_Facultad");

                entity.HasOne(d => d.IdGradoNavigation)
                    .WithMany(p => p.Estudiante)
                    .HasForeignKey(d => d.IdGrado)
                    .HasConstraintName("FK_Estudiante_Grado");
            });

            modelBuilder.Entity<Facultad>(entity =>
            {
                entity.HasKey(e => e.IdFacultad);

                entity.Property(e => e.IdFacultad).HasColumnName("idFacultad");

                entity.Property(e => e.NombreFacultad)
                    .HasColumnName("nombreFacultad")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grado>(entity =>
            {
                entity.HasKey(e => e.IdGrado);

                entity.Property(e => e.IdGrado).HasColumnName("idGrado");

                entity.Property(e => e.IdSeccion).HasColumnName("idSeccion");

                entity.Property(e => e.NombreGrado)
                    .IsRequired()
                    .HasColumnName("nombreGrado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSeccionNavigation)
                    .WithMany(p => p.Grado)
                    .HasForeignKey(d => d.IdSeccion)
                    .HasConstraintName("FK_Grado_Seccion");
            });

            modelBuilder.Entity<Maestro>(entity =>
            {
                entity.HasKey(e => e.IdMaestro);

                entity.Property(e => e.IdMaestro).HasColumnName("idMaestro");

                entity.Property(e => e.NombreMaestro)
                    .IsRequired()
                    .HasColumnName("nombreMaestro")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seccion>(entity =>
            {
                entity.HasKey(e => e.IdSeccion);

                entity.Property(e => e.IdSeccion).HasColumnName("idSeccion");

                entity.Property(e => e.NombreSeccion)
                    .HasColumnName("nombreSeccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

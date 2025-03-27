using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoAYD1_HOSPITAL.Models;

public partial class bdAYD : DbContext
{
    public bdAYD()
    {
    }

    public bdAYD(DbContextOptions<bdAYD> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCita> TbCitas { get; set; }

    public virtual DbSet<TbHistoriaClinica> TbHistoriaClinicas { get; set; }

    public virtual DbSet<TbMedico> TbMedicos { get; set; }

    public virtual DbSet<TbPaciente> TbPacientes { get; set; }

    public virtual DbSet<TbPrescripcione> TbPrescripciones { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ZIAHRA-VALLE\\SQLEXPRESS;Initial Catalog=AYD;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCita>(entity =>
        {
            entity.HasKey(e => e.CitaId).HasName("PK__TB_CITAS__5AC1B05B8430FFC6");

            entity.ToTable("TB_CITAS");

            entity.Property(e => e.CitaId).HasColumnName("cita_id");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente")
                .HasColumnName("estado");
            entity.Property(e => e.FechaCita)
                .HasColumnType("datetime")
                .HasColumnName("fecha_cita");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.MedicoId).HasColumnName("medico_id");
            entity.Property(e => e.Motivo)
                .HasColumnType("text")
                .HasColumnName("motivo");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");

            entity.HasOne(d => d.Medico).WithMany(p => p.TbCita)
                .HasForeignKey(d => d.MedicoId)
                .HasConstraintName("FK__TB_CITAS__medico__4222D4EF");

            entity.HasOne(d => d.Paciente).WithMany(p => p.TbCita)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK__TB_CITAS__pacien__412EB0B6");
        });

        modelBuilder.Entity<TbHistoriaClinica>(entity =>
        {
            entity.HasKey(e => e.HistoriaId).HasName("PK__TB_HISTO__6EF4CCD8AA74538C");

            entity.ToTable("TB_HISTORIA_CLINICA");

            entity.Property(e => e.HistoriaId).HasColumnName("historia_id");
            entity.Property(e => e.Diagnostico)
                .HasColumnType("text")
                .HasColumnName("diagnostico");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Observaciones)
                .HasColumnType("text")
                .HasColumnName("observaciones");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.Tratamiento)
                .HasColumnType("text")
                .HasColumnName("tratamiento");

            entity.HasOne(d => d.Paciente).WithMany(p => p.TbHistoriaClinicas)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK__TB_HISTOR__pacie__45F365D3");
        });

        modelBuilder.Entity<TbMedico>(entity =>
        {
            entity.HasKey(e => e.MedicoId).HasName("PK__TB_MEDIC__CCFB440FBB81F9D1");

            entity.ToTable("TB_MEDICOS");

            entity.Property(e => e.MedicoId).HasColumnName("medico_id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("especialidad");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<TbPaciente>(entity =>
        {
            entity.HasKey(e => e.PacienteId).HasName("PK__TB_PACIE__46FEF6563360302A");

            entity.ToTable("TB_PACIENTES");

            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Direccion)
                .HasColumnType("text")
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumIdentificacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("num_identificacion");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<TbPrescripcione>(entity =>
        {
            entity.HasKey(e => e.PrescripcionId).HasName("PK__TB_PRESC__A6D287D5EBE3B9EA");

            entity.ToTable("TB_PRESCRIPCIONES");

            entity.Property(e => e.PrescripcionId).HasColumnName("prescripcion_id");
            entity.Property(e => e.Dosis)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dosis");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.HistoriaId).HasColumnName("historia_id");
            entity.Property(e => e.Indicaciones)
                .HasColumnType("text")
                .HasColumnName("indicaciones");
            entity.Property(e => e.Medicamento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("medicamento");
            entity.Property(e => e.MedicoId).HasColumnName("medico_id");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");

            entity.HasOne(d => d.Historia).WithMany(p => p.TbPrescripciones)
                .HasForeignKey(d => d.HistoriaId)
                .HasConstraintName("FK__TB_PRESCR__histo__49C3F6B7");

            entity.HasOne(d => d.Medico).WithMany(p => p.TbPrescripciones)
                .HasForeignKey(d => d.MedicoId)
                .HasConstraintName("FK__TB_PRESCR__medic__4AB81AF0");

            entity.HasOne(d => d.Paciente).WithMany(p => p.TbPrescripciones)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK__TB_PRESCR__pacie__4BAC3F29");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__TB_USUAR__2ED7D2AF96844805");

            entity.ToTable("TB_USUARIO");

            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.PacienteId).HasColumnName("paciente_id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("rol");

            entity.HasOne(d => d.Paciente).WithMany(p => p.TbUsuarios)
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK__TB_USUARI__pacie__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

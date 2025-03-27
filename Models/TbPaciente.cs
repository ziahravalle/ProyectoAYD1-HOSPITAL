using System;
using System.Collections.Generic;

namespace ProyectoAYD1_HOSPITAL.Models;

public partial class TbPaciente
{
    public int PacienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Genero { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public string? NumIdentificacion { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<TbCita> TbCita { get; set; } = new List<TbCita>();

    public virtual ICollection<TbHistoriaClinica> TbHistoriaClinicas { get; set; } = new List<TbHistoriaClinica>();

    public virtual ICollection<TbPrescripcione> TbPrescripciones { get; set; } = new List<TbPrescripcione>();

    public virtual ICollection<TbUsuario> TbUsuarios { get; set; } = new List<TbUsuario>();
}

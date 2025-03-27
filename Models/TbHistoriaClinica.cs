using System;
using System.Collections.Generic;

namespace ProyectoAYD1_HOSPITAL.Models;

public partial class TbHistoriaClinica
{
    public int HistoriaId { get; set; }

    public int? PacienteId { get; set; }

    public DateOnly Fecha { get; set; }

    public string? Diagnostico { get; set; }

    public string? Tratamiento { get; set; }

    public string? Observaciones { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual TbPaciente? Paciente { get; set; }

    public virtual ICollection<TbPrescripcione> TbPrescripciones { get; set; } = new List<TbPrescripcione>();
}

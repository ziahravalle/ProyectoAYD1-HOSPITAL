using System;
using System.Collections.Generic;

namespace ProyectoAYD1_HOSPITAL.Models;

public partial class TbPrescripcione
{
    public int PrescripcionId { get; set; }

    public int? HistoriaId { get; set; }

    public string Medicamento { get; set; } = null!;

    public int? MedicoId { get; set; }

    public int? PacienteId { get; set; }

    public string Dosis { get; set; } = null!;

    public string? Indicaciones { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual TbHistoriaClinica? Historia { get; set; }

    public virtual TbMedico? Medico { get; set; }

    public virtual TbPaciente? Paciente { get; set; }
}

using System;
using System.Collections.Generic;

namespace ProyectoAYD1_HOSPITAL.Models;

public partial class TbCita
{
    public int CitaId { get; set; }

    public int? PacienteId { get; set; }

    public int? MedicoId { get; set; }

    public DateTime FechaCita { get; set; }

    public string? Motivo { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual TbMedico? Medico { get; set; }

    public virtual TbPaciente? Paciente { get; set; }
}

using System;
using System.Collections.Generic;

namespace ProyectoAYD1_HOSPITAL.Models;

public partial class TbUsuario
{
    public int UsuarioId { get; set; }

    public int? PacienteId { get; set; }

    public string Password { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public virtual TbPaciente? Paciente { get; set; }
}

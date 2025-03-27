using System;
using System.Collections.Generic;

namespace ProyectoAYD1_HOSPITAL.Models;

public partial class TbMedico
{
    public int MedicoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Especialidad { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<TbCita> TbCita { get; set; } = new List<TbCita>();

    public virtual ICollection<TbPrescripcione> TbPrescripciones { get; set; } = new List<TbPrescripcione>();
}

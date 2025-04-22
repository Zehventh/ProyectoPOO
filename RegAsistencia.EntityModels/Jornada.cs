using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegAsistencia.EntityModels;

public partial class Jornada
{
    [Key]
    public int IdJornada { get; set; }

    [Required]
    [Column(TypeName = "NVARCHAR (20)")]
    public string Codigo { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime? HoraInicioDomingo { get; set; }
    
    [Column(TypeName = "DATETIME")]
    public DateTime? HoraFinalDomingo { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime? HoraInicioLunes { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime? HoraFinalLunes { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime? HoraInicioMartes { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime? HoraFinalMartes { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime? HoraInicioMiércoles { get; set; }
    
    [Column(TypeName = "DATETIME")]
    public DateTime? HoraFinalMiércoles { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime? HoraInicioJueves { get; set; }
    
    [Column(TypeName = "DATETIME")]
    public DateTime? HoraFinalJueves { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime? HoraInicioViernes { get; set; }
    
    [Column(TypeName = "DATETIME")]
    public DateTime? HoraFinalViernes { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime? HoraInicioSábado { get; set; }
    
    [Column(TypeName = "DATETIME")]
    public DateTime? HoraFinalSábado { get; set; }
  
    [InverseProperty("Jornada")]
    public virtual ICollection<Empleado>? Empleados { get; set; } = new List<Empleado>();

    [InverseProperty("Jornada")]
    public virtual ICollection<Asistencia> Asistencias { get; set; } = new List<Asistencia>();
}
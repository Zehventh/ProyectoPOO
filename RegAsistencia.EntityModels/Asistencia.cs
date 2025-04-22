using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegAsistencia.EntityModels;

public partial class Asistencia
{

    [Key]
    public int IdAsistencia {get; set;}
    
    [Column(TypeName = "DATETIME")]
    public DateTime? Fecha {get; set;}

    [ForeignKey("IdJornada")]
    public int? IdJornada { get; set; }
    public virtual Jornada? Jornada { get; set; }

    [ForeignKey("NroEmpleado")]
    public int? NroEmpleado { get; set; }
    public virtual Empleado? Empleado { get; set; }

    [NotMapped]
    public int MinutosAusentes { get; set; }
}
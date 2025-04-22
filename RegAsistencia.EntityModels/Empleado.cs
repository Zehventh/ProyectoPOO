using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegAsistencia.EntityModels;

public partial class Empleado
{

    [Key]
    public int NroEmpleado {get; set;} 

    public string Nombre { get; set;} = null!;

    public string Apellido { get; set;} = null!;

    public string Género {get; set;} = null!;

    public int? IdDepartamento { get; set; } 

    [ForeignKey("IdJornada")]
    public virtual Jornada? Jornada { get; set; }
    
    // [ForeignKey("IdAsistencia")]
    //  public virtual Asistencia? Asistencia {get; set;}
       
    [ForeignKey("IdDepartamento")]
    public virtual Departamento? Departamento {get; set;}

    public virtual ICollection<Asistencia>? Asistencias {get; set;} = new List<Asistencia>();
}
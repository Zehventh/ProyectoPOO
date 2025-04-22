using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RegAsistencia.EntityModels;

public partial class Departamento
{
    [Key]
    public int IdDepartamento {get; set;}

    [Required]
    [Column(TypeName = "NVARCHAR (90)")]
    public string Nombre { get; set;} = null!;

    [InverseProperty("Departamento")]     //Que es esto?
    public ICollection<Empleado> Empleados {get; set;} = new List<Empleado>();
    
}


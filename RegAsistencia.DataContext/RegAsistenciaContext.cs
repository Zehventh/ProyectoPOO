using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using RegAsistencia.EntityModels;

public partial class RegAsistenciaContext : DbContext
{
    public RegAsistenciaContext() {}

    public RegAsistenciaContext(DbContextOptions<RegAsistenciaContext> options) : base(options) {}

    public virtual DbSet<Departamento> Departamentos { get; set;}

    public virtual DbSet<Asistencia> Asistencias { get; set;}

    public virtual DbSet<Empleado> Empleados { get; set;}

    public virtual DbSet<Jornada> Jornadas { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   
    {
        if (!optionsBuilder.IsConfigured)
        {
            string database = "RegAsistencia.db";
            string dir = Environment.CurrentDirectory;
            string path = string.Empty;

            if (dir.EndsWith("net8.0"))                
            {

                path = Path.Combine("..", "..", "..", "..", database);
            }
            else
            {

                path = Path.Combine("..", database);
            }

            path = Path.GetFullPath(path); 

            try
            {
                RegAsistenciaContextLogger.WriteLine($"Database path: {path}");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(message: $"{path} not found.", fileName: path);
            }

            optionsBuilder.UseSqlite($"Data Source={path}");

            optionsBuilder.LogTo(
                RegAsistenciaContextLogger.WriteLine,
                new[]
                {
                    Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting,
                }
            );
        }
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder){


        modelBuilder.Entity<Empleado>(entity =>
        {

            entity                              
                .HasOne(e => e.Departamento)             //Un empleado tiene un departamento
                .WithMany(d => d.Empleados)              //Un departamento tiene muchos empleados
                .HasForeignKey(e => e.IdDepartamento )   //Llave foranea
                .OnDelete(DeleteBehavior.Restrict); 

            /* entity
                .Property(e => e.Género)
                .HasColumnType("TEXT"); 
                
            entity                              
                .HasOne(e => e.Jornada)                  //Un empleado tienen una jornada
                .WithMany(d => d.Empleados)              //Una jornada tiene muchos empleados
                .HasForeignKey(e => e.IdJornada )        //Llave foranea
                .OnDelete(DeleteBehavior.Restrict); */   

        });

        modelBuilder.Entity<Asistencia>(entity =>
        {

            entity                              
                .HasOne(a => a.Empleado)                //Una asistencia solo tiene a un empleado
                .WithMany(e => e.Asistencias)           //Un empleado tiene muchas asistencias
                .HasForeignKey(a => a.NroEmpleado)     //Llave foranea
                .OnDelete(DeleteBehavior.Cascade);  

            entity                              
                .HasOne(a => a.Jornada) 
                .WithMany(j => j.Asistencias)               //Una asistencia solo tiene una jornada
                .HasForeignKey(a => a.IdJornada)      //Llave foranea
                .OnDelete(DeleteBehavior.Cascade);  



        });

        modelBuilder.Entity<Jornada>()
            .Property(j => j.Codigo)
            .HasMaxLength(20)
            .IsRequired(); // Asegura que 'Codigo' sea obligatorio

        // Configura el auto-incremento explícitamente si lo necesitas
        modelBuilder.Entity<Jornada>()
            .Property(j => j.IdJornada)
            .ValueGeneratedOnAdd(); // Establece que IdJornada es un campo autoincrementable


        OnModelCreatingPartial(modelBuilder);       
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder); 
}

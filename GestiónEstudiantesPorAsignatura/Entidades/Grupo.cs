using GestiónEstudiantesPorAsignatura.Entidades.Estudiantes.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónEstudiantesPorAsignatura.Entidades
{
    public class Grupo
    {
        public string NombreGrupo { get; set; }

        public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();


        public Grupo(string nombreGrupo )
        {
            NombreGrupo = nombreGrupo;
            Estudiantes = new List<Estudiante>();


        }


        public  void  AgregarEstudianteAGrupo(Estudiante estudiante)
        {
            
            Estudiantes.Add(estudiante);

        }

        public void MostrarListadoCalificaciones()
        {
            Console.WriteLine($"Listado de calificaciones para el grupo {NombreGrupo}:");
            if (Estudiantes.Count == 0) Console.WriteLine("No hay estudiantes inscritos.");

            foreach (var est in Estudiantes)
                est.MostrarDatos();
        }



    

        public double PorcentajeEstudiantesPasados()
        {
            if (Estudiantes.Count == 0) return 0;
            int aprobados = Estudiantes.Count(e => e.CalcularNotaFinal() >= 70);
            return ((double)aprobados / Estudiantes.Count) * 100;
        }

    }
}

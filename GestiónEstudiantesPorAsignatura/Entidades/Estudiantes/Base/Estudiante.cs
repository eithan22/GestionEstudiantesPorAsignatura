using GestiónEstudiantesPorAsignatura.Entidades.Estudiantes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónEstudiantesPorAsignatura.Entidades.Estudiantes.Base
{
    public abstract class Estudiante
    {
        public string Nombre { get; set; }
        public string Matricula { get; set; }

        public List<double> CalificacionesPractica { get; set; } 
        public List<double> CalificacionesExamen { get; set; }

        public Estudiante (string nombre, string matricula)
        {
            Nombre = nombre;
            Matricula = matricula;
            CalificacionesExamen = new List<double>();
            CalificacionesPractica = new List<double>();

        }

        public void agregarCalificacionExamen(double nota)
        {
            CalificacionesExamen.Add(nota);
        }


        public void agregarCalificacionPractica(double nota)
        {
            CalificacionesPractica.Add(nota);

        }

        public abstract double CalcularNotaFinal();

        public abstract void MostrarDatos();
    }
}

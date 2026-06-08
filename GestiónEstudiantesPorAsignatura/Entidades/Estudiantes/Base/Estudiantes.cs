using GestiónEstudiantesPorAsignatura.Entidades.Estudiantes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónEstudiantesPorAsignatura.Entidades.Estudiantes.Base
{
    public abstract class Estudiantes
    {
        public string Nombre { get; set; }
        public string Matricula { get; set; }

        public List<double>Calificaciones { get; set; }


        public Estudiantes (string nombre, string matricula)
        {
            Nombre = nombre;
            Matricula = matricula;
            Calificaciones = new List<double>();
            
        }

        public abstract double CalcularNotaFinal();











        
         











    }
}

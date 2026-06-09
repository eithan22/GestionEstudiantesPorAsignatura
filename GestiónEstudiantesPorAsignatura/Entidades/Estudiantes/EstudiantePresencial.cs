using GestiónEstudiantesPorAsignatura.Entidades;
using GestiónEstudiantesPorAsignatura.Entidades.Estudiantes.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónEstudiantesPorAsignatura.Entidades.Estudiantes
{
    public class EstudiantePresencial : Estudiante
    {

        public EstudiantePresencial(string nombre, string matricula) : base(nombre, matricula) { }



        public override double CalcularNotaFinal()
        {
            double promedioPractica = 0;
            double promedioExamen = 0;

            if (CalificacionesPractica.Count > 0 )
            {
                promedioPractica = CalificacionesPractica.Average();
            }
            if (CalificacionesExamen.Count > 0)
            {
                promedioExamen = CalificacionesExamen.Average();
            }


            // La nota final se calcula como el 60% del promedio de prácticas y el 40% del promedio de exámenes
            return (promedioPractica * 0.6) + (promedioExamen * 0.4);




        }
        
        public override void MostrarDatos()
        {
            Console.WriteLine($"[PRESENCIAL] {Matricula} - {Nombre} | Nota: {CalcularNotaFinal():F2}");
        }






    }
}

using GestiónEstudiantesPorAsignatura.Entidades.Estudiantes.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónEstudiantesPorAsignatura.Entidades.Estudiantes
{
    public class EstudiantesDistancial : Estudiante
    {

        public EstudiantesDistancial(string nombre, string matricula) : base(nombre, matricula) { }

        public override double CalcularNotaFinal()
        {
            double promedioPractica = 0;
            double promedioExamen = 0;

            if (CalificacionesPractica.Count > 0)
            {
                promedioPractica = CalificacionesPractica.Average();
            }
            if (CalificacionesExamen.Count > 0)
            {
                promedioExamen = CalificacionesExamen.Average();
            }


          
            //  examen pesa mas al no haber presencia  
            return (promedioPractica * 0.5) + (promedioExamen * 0.5);

        }

        public override void MostrarDatos()
        {
            Console.WriteLine($"[DISTANCIAL] {Matricula} - {Nombre} | Nota: {CalcularNotaFinal():F2}");
        }
    }
}

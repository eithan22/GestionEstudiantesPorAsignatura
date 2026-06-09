using GestiónEstudiantesPorAsignatura.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónEstudiantesPorAsignatura.Menus
{
    internal class MenuReportes
    {
        private readonly ProfesorServices _servicio;

        public MenuReportes(ProfesorServices servicio)
        {
            _servicio = servicio;
        }

        public void MostrarListado()
        {
            Console.Write("Materia: ");
            string materia = Console.ReadLine();

            Console.Write("Grupo: ");
            string grupo = Console.ReadLine();

            var resultado = _servicio.MostrarListadoCalificaciones(materia, grupo);
            if (!resultado.Success) Consola.Mostrar(resultado);
        }

        public void MostrarAprobados()
        {
            Console.Write("Materia: ");
            string materia = Console.ReadLine();

            Console.Write("Grupo: ");
            string grupo = Console.ReadLine();

            var resultado = _servicio.ObtenerPorcentajeAprobados(materia, grupo);

            if (resultado.Success)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nPorcentaje de aprobados: {resultado.Data:F1}%");
                Console.ResetColor();
            }
            else
            {
                Consola.Mostrar(resultado);
            }
        }
    }
}


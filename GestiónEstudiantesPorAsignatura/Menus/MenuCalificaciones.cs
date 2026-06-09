using GestiónEstudiantesPorAsignatura.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónEstudiantesPorAsignatura.Menus
{
    internal class MenuCalificaciones
    {
        private readonly ProfesorServices _servicio;

        public MenuCalificaciones(ProfesorServices servicio)
        {
            _servicio = servicio;
        }

        public void Mostrar()
        {
            Console.Write("Materia: ");
            string materia = Console.ReadLine();

            Console.Write("Grupo: ");
            string grupo = Console.ReadLine();

            Console.Write("Matricula del estudiante: ");
            string matricula = Console.ReadLine();

            Console.Write("Tipo de nota (practica / examen): ");
            string tipo = Console.ReadLine();

            Console.Write("Calificación (0-100): ");
            if (!double.TryParse(Console.ReadLine(), out double nota))
            {
                Console.WriteLine("Nota invalida.");
                return;
            }

            var resultado = _servicio.RegistrarCalificacion(materia, grupo, matricula, nota, tipo);
            Consola.Mostrar(resultado);
        }
    }
}


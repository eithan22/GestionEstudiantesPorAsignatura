using GestiónEstudiantesPorAsignatura.Entidades.Estudiantes;
using GestiónEstudiantesPorAsignatura.Entidades.Estudiantes.Base;
using GestiónEstudiantesPorAsignatura.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónEstudiantesPorAsignatura.Menus
{
    public class MenuEstudiantes
    {
        private readonly ProfesorServices _servicio;

        public MenuEstudiantes(ProfesorServices servicio)
        {
            _servicio = servicio;
        }

        public void Mostrar()
        {
            Console.Write("Materia: ");
            string materia = Console.ReadLine();

            Console.Write("Grupo: ");
            string grupo = Console.ReadLine();

            Console.Write("Nombre del alumno: ");
            string nombre = Console.ReadLine();

            Console.Write("Matricula: ");
            string matricula = Console.ReadLine();

            Console.Write("Tipo (1. Presencial  2. Distancia): ");
            string tipo = Console.ReadLine();

            Estudiante nuevo = tipo == "1"
                ? new EstudiantePresencial(nombre, matricula)
                : new EstudiantesDistancial(nombre, matricula);

            var resultado = _servicio.AgregarEstudianteAGrupo(materia, grupo, nuevo);
            Consola.Mostrar(resultado);
        }
    }
}

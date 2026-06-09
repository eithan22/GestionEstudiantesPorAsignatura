using GestiónEstudiantesPorAsignatura.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónEstudiantesPorAsignatura.Menus
{
    public class MenuAsignaturas
    {
        private readonly ProfesorServices _servicio;

        public MenuAsignaturas(ProfesorServices servicio)
        {
            _servicio = servicio;
        }

        public void Mostrar()
        {
            Console.WriteLine("\n--- GESTION DE ASIGNATURAS ---");
            Console.WriteLine("1. Registrar asignatura");
            Console.WriteLine("2. Agregar grupo a asignatura");
            Console.Write("Opcion: ");

            switch (Console.ReadLine())
            {
                case "1": RegistrarAsignatura(); break;
                case "2": AgregarGrupo(); break;
                default: Console.WriteLine("Opcion no valida."); break;
            }
        }

        private void RegistrarAsignatura()
        {
            Console.Write("Nombre de la asignatura: ");
            string nombre = Console.ReadLine();

            var resultado = _servicio.AgregarAsignatura(nombre);
            Consola.Mostrar(resultado);
        }

        private void AgregarGrupo()
        {
            Console.Write("Nombre de la asignatura: ");
            string materia = Console.ReadLine();

            Console.Write("Nombre del grupo (ej: Grupo A): ");
            string grupo = Console.ReadLine();

            var resultado = _servicio.AgregarGrupoAAsignatura(materia, grupo);
            Consola.Mostrar(resultado);
        }
    }
}


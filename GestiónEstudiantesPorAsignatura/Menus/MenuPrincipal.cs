using GestiónEstudiantesPorAsignatura.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónEstudiantesPorAsignatura.Menus
{
    public class MenuPrincipal
    {
        private readonly ProfesorServices _servicio = new ProfesorServices();

        public void Mostrar()
        {
            while (true)
            {
                Console.WriteLine("\n=== SISTEMA DE CONTROL ACADEMICO ===");
                Console.WriteLine("1. Gestionar Asignaturas y Grupos");
                Console.WriteLine("2. Agregar Estudiante");
                Console.WriteLine("3. Registrar Calificacion");
                Console.WriteLine("4. Mostrar Listado por Grupo");
                Console.WriteLine("5. Calcular porcentaje de Aprobados");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opcion: ");

                switch (Console.ReadLine())
                {
                    case "1": new MenuAsignaturas(_servicio).Mostrar(); break;
                    case "2": new MenuEstudiantes(_servicio).Mostrar(); break;
                    case "3": new MenuCalificaciones(_servicio).Mostrar(); break;
                    case "4": new MenuReportes(_servicio).MostrarListado(); break;
                    case "5": new MenuReportes(_servicio).MostrarAprobados(); break;
                    case "6": return;
                    default: Console.WriteLine("Opcion no valida."); break;
                }
            }
        }
    }
}

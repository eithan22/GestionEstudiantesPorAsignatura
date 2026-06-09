using GestiónEstudiantesPorAsignatura.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónEstudiantesPorAsignatura.Menus
{
    public static class Consola
    {
        public static void Mostrar(OperationResult result)
        {
            Console.ForegroundColor = result.Success
                ? ConsoleColor.Green
                : ConsoleColor.Red;

            Console.WriteLine("\n" + result.Message);
            Console.ResetColor();
        }

    }
}

using GestiónEstudiantesPorAsignatura.Data;
using GestiónEstudiantesPorAsignatura.Entidades;
using GestiónEstudiantesPorAsignatura.Entidades.Estudiantes.Base;
using GestiónEstudiantesPorAsignatura.Interfaces;
using GestiónEstudiantesPorAsignatura.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónEstudiantesPorAsignatura.Service
{
    public class ProfesorServices : IProfesorServices
    {


        // Método para agregar una nueva asignatura al sistema
        public OperationResult AgregarAsignatura(string nombreMateria)
        {
            if (string.IsNullOrWhiteSpace(nombreMateria))
                return new OperationResult(false, "El nombre de la materia no puede estar vacío.");

            bool existe = AsignaturaRepository.Asignatura
                .Any(a => a.NombreMateria.ToLower() == nombreMateria.ToLower());

            if (existe)
                return new OperationResult(false, $"La asignatura '{nombreMateria}' ya existe.");

            AsignaturaRepository.Asignatura.Add(new Asignaturas(nombreMateria));

            return new OperationResult(true, $"Asignatura '{nombreMateria}' registrada correctamente.");
        }


        // Método para agregar un estudiante a un grupo específico dentro de una asignatura
        public OperationResult AgregarEstudianteAGrupo(string materia, string grupoNombre, Estudiante estudiante)
        {
            var asignatura = AsignaturaRepository.Asignatura.FirstOrDefault(a => a.NombreMateria.ToLower() == materia.ToLower());
            if (asignatura == null) return new OperationResult(false, "Asignatura no encontrada.");

            var grupo = asignatura.Grupos.FirstOrDefault(g => g.NombreGrupo.ToLower() == grupoNombre.ToLower());
            if (grupo == null) return new OperationResult(false, "Grupo no encontrado.");

           
            bool existe = grupo.Estudiantes.Any(e => e.Matricula == estudiante.Matricula);
            if (existe)
                return new OperationResult(false, $"La matrícula '{estudiante.Matricula}' ya existe en el grupo.");



            grupo.AgregarEstudianteAGrupo(estudiante);
            return new OperationResult(true, $"El estudiante {estudiante.Nombre} fue agregado correctamente.");
        }


    




        // Método para agregar un nuevo grupo a una asignatura existente 

        public OperationResult AgregarGrupoAAsignatura(string nombreMateria, string nombreNuevoGrupo)
        {
            //  Buscamos la asignatura
            var asignatura = AsignaturaRepository.Asignatura.FirstOrDefault(a => a.NombreMateria.ToLower() == nombreMateria.ToLower());

            if (asignatura == null)
                return new OperationResult(false, "Error: La asignatura no existe.");

            //  Verificamos si el grupo ya existe para no duplicarlo
            if (asignatura.Grupos.Any(g => g.NombreGrupo.ToLower() == nombreNuevoGrupo.ToLower()))
                return new OperationResult(false, "Error: Este grupo ya existe en esta asignatura.");

            // Creamos y agregamos el grupo
            var nuevoGrupo = new Grupo(nombreNuevoGrupo);
            asignatura.AgregarGrupoAsignatura(nuevoGrupo);

            return new OperationResult(true, $"El grupo {nombreNuevoGrupo} fue agregado a {asignatura.NombreMateria} exitosamente.");
        }



        // Método para mostrar el listado de calificaciones de un grupo específico dentro de una asignatura

        public OperationResult MostrarListadoCalificaciones(string materia, string grupoNombre)
        {
            var asignatura = AsignaturaRepository.Asignatura.FirstOrDefault(a => a.NombreMateria.ToLower() == materia.ToLower());
            if (asignatura == null) return new OperationResult(false, "Asignatura no encontrada.");


            var grupo = asignatura.Grupos.FirstOrDefault(g => g.NombreGrupo.ToLower() == grupoNombre.ToLower());
            if (grupo == null) return new OperationResult(false, "Grupo no encontrado.");

            grupo.MostrarListadoCalificaciones();
            return new OperationResult(true, "Listado mostrado exitosamente.");
        }




        // Método para calcular el porcentaje de estudiantes aprobados en un grupo específico dentro de una asignatura
        public OperationResult ObtenerPorcentajeAprobados(string materia, string grupoNombre)
        {
            var asignatura = AsignaturaRepository.Asignatura.FirstOrDefault(a => a.NombreMateria.ToLower() == materia.ToLower());
            if (asignatura == null) return new OperationResult(false, "Asignatura no encontrada.");


            var grupo = asignatura.Grupos.FirstOrDefault(g => g.NombreGrupo.ToLower() == grupoNombre.ToLower());
            if (grupo == null) return new OperationResult(false, "Grupo no encontrado.");

            double porcentaje = grupo.PorcentajeEstudiantesPasados();
            return new OperationResult(true, "Cálculo exitoso.", porcentaje);
        }



        // Método para registrar una calificación para un estudiante específico en un grupo y asignatura determinados

        public OperationResult RegistrarCalificacion(string materia, string grupoNombre, string matricula, double nota, string tipo)
        {
            var asignatura = AsignaturaRepository.Asignatura.FirstOrDefault(a => a.NombreMateria.ToLower() == materia.ToLower());
            if (asignatura == null) return new OperationResult(false, "Asignatura no encontrada.");


            var grupo = asignatura.Grupos.FirstOrDefault(g => g.NombreGrupo.ToLower() == grupoNombre.ToLower());
            if (grupo == null) return new OperationResult(false, "Grupo no encontrado.");


            var est = grupo.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (est == null) return new OperationResult(false, "Estudiante no encontrado.");


            if (nota < 0 || nota > 100) return new OperationResult(false, "La nota debe ser entre 0 y 100.");

            if (tipo.ToLower() == "practica") est.agregarCalificacionPractica(nota);
            else if (tipo.ToLower() == "examen") est.agregarCalificacionExamen(nota);

            else return new OperationResult(false, "Tipo de nota invalida.");

            return new OperationResult(true, "Calificación registrada con éxito.");
        }
    }
}

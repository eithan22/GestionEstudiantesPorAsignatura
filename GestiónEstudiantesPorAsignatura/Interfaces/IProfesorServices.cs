using GestiónEstudiantesPorAsignatura.Entidades.Estudiantes.Base;
using GestiónEstudiantesPorAsignatura.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónEstudiantesPorAsignatura.Interfaces
{
    public interface IProfesorServices
    {
        public OperationResult AgregarEstudianteAGrupo(string materia, string grupoNombre, Estudiante estudiante);

        public OperationResult RegistrarCalificacion(string materia, string grupoNombre, string matricula, double nota, string tipo);

        public OperationResult MostrarListadoCalificaciones(string materia, string grupoNombre);

        public OperationResult ObtenerPorcentajeAprobados(string materia, string grupoNombre);

        public OperationResult AgregarGrupoAAsignatura(string nombreMateria, string nombreNuevoGrupo);

        public OperationResult AgregarAsignatura(string nombreMateria);

        
    }






}

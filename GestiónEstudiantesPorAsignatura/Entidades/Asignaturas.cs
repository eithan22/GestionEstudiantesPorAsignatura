using System;
using System.Collections.Generic;
using System.Text;
using GestiónEstudiantesPorAsignatura.Response;

namespace GestiónEstudiantesPorAsignatura.Entidades
{
    public class Asignaturas
    {
        public string NombreMateria{ get; set; }
        public List<Grupo> Grupos { get; set; } = new List<Grupo>();

        public Asignaturas(string nombreMateria)
        {
            NombreMateria = nombreMateria;
            Grupos = new List<Grupo>();
        }


        public void  AgregarGrupoAsignatura (Grupo nuevogrupo)
        {
            Grupos.Add(nuevogrupo);

        }




    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GestiónEstudiantesPorAsignatura.Response
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public dynamic Data { get; set; }

        public OperationResult(bool success, string menssge, dynamic data = null)
        {
            Success = success;
            Message = menssge;
            Data = data;


        }


    }
}

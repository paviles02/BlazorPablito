using System;
using System.Collections.Generic;

namespace BlazorPablito.Server.Models
{
    public partial class DireccionEstudiante
    {
        public int IdDireccionEstudiante { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }

        public virtual Estudiante IdDireccionEstudianteNavigation { get; set; }
    }
}

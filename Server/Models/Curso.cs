using System;
using System.Collections.Generic;

namespace BlazorPablito.Server.Models
{
    public partial class Curso
    {
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public string Descripcion { get; set; }
        public int? IdMaestro { get; set; }

        public virtual Maestro IdMaestroNavigation { get; set; }
    }
}

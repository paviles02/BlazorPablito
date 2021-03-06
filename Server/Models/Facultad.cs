using System;
using System.Collections.Generic;

namespace BlazorPablito.Server.Models
{
    public partial class Facultad
    {
        public Facultad()
        {
            Estudiante = new HashSet<Estudiante>();
        }

        public int IdFacultad { get; set; }
        public string NombreFacultad { get; set; }

        public virtual ICollection<Estudiante> Estudiante { get; set; }
    }
}

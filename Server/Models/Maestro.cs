using System;
using System.Collections.Generic;

namespace BlazorPablito.Server.Models
{
    public partial class Maestro
    {
        public Maestro()
        {
            Curso = new HashSet<Curso>();
        }

        public int IdMaestro { get; set; }
        public string NombreMaestro { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
    }
}

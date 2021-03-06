using System;
using System.Collections.Generic;

namespace BlazorPablito.Server.Models
{
    public partial class Seccion
    {
        public Seccion()
        {
            Grado = new HashSet<Grado>();
        }

        public int IdSeccion { get; set; }
        public string NombreSeccion { get; set; }

        public virtual ICollection<Grado> Grado { get; set; }
    }
}

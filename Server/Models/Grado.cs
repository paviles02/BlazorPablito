using System;
using System.Collections.Generic;

namespace BlazorPablito.Server.Models
{
    public partial class Grado
    {
        public Grado()
        {
            Estudiante = new HashSet<Estudiante>();
        }

        public int IdGrado { get; set; }
        public string NombreGrado { get; set; }
        public int? IdSeccion { get; set; }

        public virtual Seccion IdSeccionNavigation { get; set; }
        public virtual ICollection<Estudiante> Estudiante { get; set; }
    }
}

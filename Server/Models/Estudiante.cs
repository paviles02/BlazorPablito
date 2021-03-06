using System;
using System.Collections.Generic;

namespace BlazorPablito.Server.Models
{
    public partial class Estudiante
    {
        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public decimal? Altura { get; set; }
        public decimal? Peso { get; set; }
        public int? IdFacultad { get; set; }
        public int? IdGrado { get; set; }

        public virtual Facultad IdFacultadNavigation { get; set; }
        public virtual Grado IdGradoNavigation { get; set; }
        public virtual DireccionEstudiante DireccionEstudiante { get; set; }
    }
}

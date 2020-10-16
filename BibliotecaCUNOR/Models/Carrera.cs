using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            TrabajoGraduacion = new HashSet<TrabajoGraduacion>();
            Usuario = new HashSet<Usuario>();
        }

        public int CodCarrera { get; set; }
        public string Carrera1 { get; set; }

        public virtual ICollection<TrabajoGraduacion> TrabajoGraduacion { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}

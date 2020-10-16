using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class Asesor
    {
        public Asesor()
        {
            TrabajoGraduacion = new HashSet<TrabajoGraduacion>();
        }

        public int CodAsesor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual ICollection<TrabajoGraduacion> TrabajoGraduacion { get; set; }
    }
}

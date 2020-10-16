using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class CatTrabajoGraduacion
    {
        public CatTrabajoGraduacion()
        {
            TrabajoGraduacion = new HashSet<TrabajoGraduacion>();
        }

        public int CodCat { get; set; }
        public string Categoria { get; set; }

        public virtual ICollection<TrabajoGraduacion> TrabajoGraduacion { get; set; }
    }
}

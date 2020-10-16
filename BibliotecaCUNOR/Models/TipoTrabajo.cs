using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class TipoTrabajo
    {
        public TipoTrabajo()
        {
            TrabajoGraduacion = new HashSet<TrabajoGraduacion>();
        }

        public int CodTipotrabajo { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<TrabajoGraduacion> TrabajoGraduacion { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class Observacion
    {
        public int CodObservacion { get; set; }
        public string Observacion1 { get; set; }
        public int CodLibro { get; set; }

        public virtual Libro CodLibroNavigation { get; set; }
    }
}

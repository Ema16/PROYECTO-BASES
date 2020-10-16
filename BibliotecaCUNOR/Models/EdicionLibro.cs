using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class EdicionLibro
    {
        public int CodEdicionLibro { get; set; }
        public int CodLibro { get; set; }
        public int CodEdicion { get; set; }

        public virtual Edicion CodEdicionNavigation { get; set; }
        public virtual Libro CodLibroNavigation { get; set; }
    }
}

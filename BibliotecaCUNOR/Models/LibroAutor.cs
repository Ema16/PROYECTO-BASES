using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class LibroAutor
    {
        public int CodLibroAutor { get; set; }
        public int CodLibro { get; set; }
        public int CodAutor { get; set; }

        public virtual Autor CodAutorNavigation { get; set; }
        public virtual Libro CodLibroNavigation { get; set; }
    }
}

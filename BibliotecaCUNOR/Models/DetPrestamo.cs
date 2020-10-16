using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class DetPrestamo
    {
        public int CodDetallePrestamo { get; set; }
        public string Estado { get; set; }
        public int CodPrestamo { get; set; }
        public int CodLibro { get; set; }

        public virtual Libro CodLibroNavigation { get; set; }
        public virtual Prestamo CodPrestamoNavigation { get; set; }
    }
}

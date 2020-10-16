using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class BitacoraLibro
    {
        public int CodBitacora { get; set; }
        public string TituloLibro { get; set; }
        public string ClaveLibro { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
        public string Usuario { get; set; }
        public int CodLibro { get; set; }

        public virtual Libro CodLibroNavigation { get; set; }
    }
}

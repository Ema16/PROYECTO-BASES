using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class BitacoraTrabajo
    {
        public int CodBitacoratrabajo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
        public string Usuario { get; set; }
        public int CodRegistro { get; set; }

        public virtual TrabajoGraduacion CodRegistroNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class TrabajoPalabraClave
    {
        public int CodTrabajoPalabraclave { get; set; }
        public int CodRegistro { get; set; }
        public int CodPalabraClave { get; set; }

        public virtual PalabraClave CodPalabraClaveNavigation { get; set; }
        public virtual TrabajoGraduacion CodRegistroNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class PalabraClave
    {
        public PalabraClave()
        {
            TrabajoPalabraClave = new HashSet<TrabajoPalabraClave>();
        }

        public int CodPalabraclave { get; set; }
        public string PalabraClave1 { get; set; }

        public virtual ICollection<TrabajoPalabraClave> TrabajoPalabraClave { get; set; }
    }
}

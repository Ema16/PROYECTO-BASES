using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class Edicion
    {
        public Edicion()
        {
            EdicionLibro = new HashSet<EdicionLibro>();
        }

        public int CodEdicion { get; set; }
        public string Edicion1 { get; set; }

        public virtual ICollection<EdicionLibro> EdicionLibro { get; set; }
    }
}

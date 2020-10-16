using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class Editorial
    {
        public Editorial()
        {
            Libro = new HashSet<Libro>();
        }

        public int CodEditorial { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}

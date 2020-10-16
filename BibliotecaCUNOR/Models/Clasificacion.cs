using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class Clasificacion
    {
        public Clasificacion()
        {
            Libro = new HashSet<Libro>();
        }

        public int CodClasificacion { get; set; }
        public string CodigoClase { get; set; }
        public string CodigoDivision { get; set; }
        public string CodigoClasificacion { get; set; }
        public string Clase { get; set; }
        public string Division { get; set; }
        public string Clasificacion1 { get; set; }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name ="Clasificacion del Libro")]
        public string ClasificacionFull
        {
            get { 
                return CodigoClase + " " + CodigoDivision + " " + CodigoClasificacion + " " + Clase + " " + Division + " " + Clasificacion1; 
            }
        }

        public virtual ICollection<Libro> Libro { get; set; }
    }
}

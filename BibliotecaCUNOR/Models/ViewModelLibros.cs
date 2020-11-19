using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaCUNOR.Models
{
    public class ViewModelLibros
    {
        public int CodLibro { get; set; }
        public string Clave { get; set; }
        public string Titulo { get; set; }
        public int? Ejemplares { get; set; }
        public string Editorial { get; set; }
        public string Edicion { get; set; }
    }
}

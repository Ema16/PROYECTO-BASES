using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaCUNOR.Models
{
    public class ViewModelTrabajo
    {
        public int CodRegistro { get; set; }
        public string Titulo { get; set; }
        public string Institucion { get; set; }
        public string NombreAutor { get; set; }
        public string ApellidoAutor { get; set; }
        public int Año { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaCUNOR.Models
{
    public class ViewModel
    {
        public int CodPrestamo { get; set; }
        public string Libro { get; set; }
        public string NombreUsuario { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaRecepcion { get; set; }
    }
}

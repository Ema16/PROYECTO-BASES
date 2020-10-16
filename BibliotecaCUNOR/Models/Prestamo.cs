using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class Prestamo
    {
        public Prestamo()
        {
            DetPrestamo = new HashSet<DetPrestamo>();
        }

        public int CodPrestamo { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public int? Mora { get; set; }
        public string Tipo { get; set; }
        public int CodUsuario { get; set; }

        public virtual Usuario CodUsuarioNavigation { get; set; }
        public virtual ICollection<DetPrestamo> DetPrestamo { get; set; }
    }
}

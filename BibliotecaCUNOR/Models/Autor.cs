using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaCUNOR.Models
{
    public partial class Autor
    {
        public Autor()
        {
            LibroAutor = new HashSet<LibroAutor>();
        }

        public int CodAutor { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        public virtual ICollection<LibroAutor> LibroAutor { get; set; }
    }
}

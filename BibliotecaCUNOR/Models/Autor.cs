using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaCUNOR.Models
{
    public partial class Autor
    {
        public Autor()
        {
            LibroAutor = new HashSet<LibroAutor>();
        }

        public int CodAutor { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        [Display(Name = "Full Name Autor")]
        public string FullName
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }
        public virtual ICollection<LibroAutor> LibroAutor { get; set; }
    }
}

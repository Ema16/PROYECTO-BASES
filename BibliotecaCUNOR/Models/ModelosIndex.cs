using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaCUNOR.Models
{
    public class ModelosIndex
    {
        public ModelosIndex()
        {
            Administradors = new List<Administrador>();
            Estudiantes = new List<Estudiante>();
            Bibliotecarios = new List<Bibliotecario>();
            Inventaristas = new List<Inventarista>();
        }
        public virtual ICollection<Administrador> Administradors { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Bibliotecario> Bibliotecarios { get; set; }
        public virtual ICollection<Inventarista> Inventaristas { get; set; }

      
    }
}

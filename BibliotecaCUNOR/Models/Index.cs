using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaCUNOR.Models
{
    public class Estudiante
    {
        public int countDevPen { get; set; }
        public int countPres { get; set; }
    }

    public class Bibliotecario
    {
        public int countAutores { get; set; }
        public int countLibros { get; set; }
        public int countDevPen { get; set; }
        public int countPresGe { get; set; }

    }

    public class Inventarista
    {
        public int countLibro { get; set; }
        public int countTraba { get; set; }
        public int countAsesores { get; set; }
        public int countAutor { get; set; }

    }

    
    public class Administrador
    {
        public int countAdmin { get; set; }
        public int countEstu { get; set; }
        public int countPersonal { get; set; }
    }

}

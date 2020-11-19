using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaCUNOR.Models
{
    public partial class Asesor
    {
        public Asesor()
        {
            TrabajoGraduacion = new HashSet<TrabajoGraduacion>();
        }

        public int CodAsesor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        
        [NotMapped]
        [Display(Name = "Nombre de Asesor")]
        public string FullName
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }

        public virtual ICollection<TrabajoGraduacion> TrabajoGraduacion { get; set; }
    }
}

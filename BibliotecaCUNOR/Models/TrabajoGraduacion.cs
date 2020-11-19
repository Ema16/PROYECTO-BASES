using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaCUNOR.Models
{
    public partial class TrabajoGraduacion
    {
        public TrabajoGraduacion()
        {
            BitacoraTrabajo = new HashSet<BitacoraTrabajo>();
            TrabajoPalabraClave = new HashSet<TrabajoPalabraClave>();
        }

        public int CodRegistro { get; set; }
        public string Titulo { get; set; }
        public int Año { get; set; }
        public string RecursoDigital { get; set; }
        public string TokenRecurso { get; set; }
        public string Nota { get; set; }
        public string NombreInstitucion { get; set; }
        public string NombreAutor { get; set; }
        public string ApellidoAutor { get; set; }
        public int CarnetAutor { get; set; }
        public string Observacion { get; set; }
        public int? CodCat { get; set; }
        public int CodUsuario { get; set; }
        public int CodAsesor { get; set; }
        public int CodCarrera { get; set; }
        public int? CodTipotrabajo { get; set; }

        [Required (ErrorMessage ="Debe Subir Un archivo")]
        [NotMapped]
        public IFormFile Subir { get; set; }

        [NotMapped]
        [Required (ErrorMessage ="Ingrese las etiquetas")]
        public string PalabrasClaves { get; set; }


        public virtual Asesor CodAsesorNavigation { get; set; }
        public virtual Carrera CodCarreraNavigation { get; set; }
        public virtual CatTrabajoGraduacion CodCatNavigation { get; set; }
        public virtual TipoTrabajo CodTipotrabajoNavigation { get; set; }
        public virtual Usuario CodUsuarioNavigation { get; set; }
        public virtual ICollection<BitacoraTrabajo> BitacoraTrabajo { get; set; }
        public virtual ICollection<TrabajoPalabraClave> TrabajoPalabraClave { get; set; }
    }
}

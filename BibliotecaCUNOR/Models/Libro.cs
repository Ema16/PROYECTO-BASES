﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaCUNOR.Models
{
    public partial class Libro
    {
        public Libro()
        {
            BitacoraLibro = new HashSet<BitacoraLibro>();
            DetPrestamo = new HashSet<DetPrestamo>();
            EdicionLibro = new HashSet<EdicionLibro>();
            LibroAutor = new HashSet<LibroAutor>();
            Observacion = new HashSet<Observacion>();
        }

//        [Key]
        public int CodLibro { get; set; }


   //     [Required]
        [Display(Name ="Clave del Libro")]
        public string Clave { get; set; }

     //   [Required]
        public string Titulo { get; set; }

        public int? Costo { get; set; }

      //  [Required]
        public string Estado { get; set; }


        public int? Ejemplares { get; set; }


       // [Required]
        [Display(Name ="Paginas del Libro")]
        public int Paginas { get; set; }

        public int? Volumen { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int? CodEditorial { get; set; }
        public int CodUsuario { get; set; }
        public int CodClasificacion { get; set; }


        [NotMapped]
        public List<int> MultiAutores { get; set; }

        public virtual Clasificacion CodClasificacionNavigation { get; set; }
        public virtual Editorial CodEditorialNavigation { get; set; }
        public virtual Usuario CodUsuarioNavigation { get; set; }
        public virtual ICollection<BitacoraLibro> BitacoraLibro { get; set; }
        public virtual ICollection<DetPrestamo> DetPrestamo { get; set; }
        public virtual ICollection<EdicionLibro> EdicionLibro { get; set; }
        public virtual ICollection<LibroAutor> LibroAutor { get; set; } 
        public virtual ICollection<Observacion> Observacion { get; set; }
    }
}

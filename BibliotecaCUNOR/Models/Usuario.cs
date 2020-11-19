using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaCUNOR.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Libro = new HashSet<Libro>();
            Prestamo = new HashSet<Prestamo>();
            TrabajoGraduacion = new HashSet<TrabajoGraduacion>();
        }

        public int CodUsuario { get; set; }

        [Required(ErrorMessage = "Los Nombres son necesarios")]
        public string Nombre { get; set; }



        [Required(ErrorMessage = "Los apellidos son necesarios")]
        public string Apellido { get; set; }

        [Display(Name = "Correo Electronico")]
        [Remote(action: "VerificarCorreo", controller: "Usuarios")]
        [Required(ErrorMessage = "El correo electronico es necesario")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Por favor, introduce una dirección de correo electrónico válida.")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "Es Necesario la Contraseña")]
        [StringLength(255, ErrorMessage = "La contraseña debe tener entre 8  y 255 caracteres", MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "La contraseña debe tener 8 caracteres como minimo")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }


        [Required(ErrorMessage = "Es necesario Confirmar la Contraseña")]
        [DataType(DataType.Password)]
        [Compare("Contraseña", ErrorMessage = "Las contraseñas no coiciden")]
        [NotMapped]
        public string Contraseña2 { get; set; }

        [Required(ErrorMessage = "El usuario es necesario")]
        [Remote(action: "VerificarUsuario", controller: "Usuarios")]
        [Display(Name = "Usuario")]
        [RegularExpression("[0-9]{9,9}", ErrorMessage ="Carnet Invalido")]
        public int Usuario1 { get; set; }

        
        [Required(ErrorMessage = "Ingrese su numero de telefono")]
        [RegularExpression("[0-9]{8,8}", ErrorMessage ="Numero de Telefono Invalido")]
        public int Telefono { get; set; }
        public byte[] Foto { get; set; }
        public string ActivarUsuario { get; set; }
        public string Estado { get; set; }
        public int CodRolusuario { get; set; }

        [Display(Name = "Carrera")]
        public int? CodCarrera { get; set; }
        public int? CodCargo { get; set; }

        [Display(Name = "¿Usted Es?")]
        [Required(ErrorMessage ="Seleccione una opcion")]
        public int CodTipousuario { get; set; }
        public string RecContraseña { get; set; }

        [NotMapped]
        public string cargo1 { get; set; }

        [Display(Name = "Full Name Usuario")]
        public string FullName
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }

        public virtual Carrera CodCarreraNavigation { get; set; }
        public virtual RolUsuario CodRolusuarioNavigation { get; set; }
        public virtual TipoUsuario CodTipousuarioNavigation { get; set; }
        public virtual ICollection<Libro> Libro { get; set; }
        public virtual ICollection<Prestamo> Prestamo { get; set; }
        public virtual ICollection<TrabajoGraduacion> TrabajoGraduacion { get; set; }
    }
}

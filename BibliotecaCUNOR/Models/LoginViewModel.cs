using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaCUNOR.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El correo es necesario")]
        [EmailAddress]
        [DisplayName("Correo Electronico")]
        public String Correo { get; set; }

        [Required(ErrorMessage = "La contraseña es necesaria")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
    }
}

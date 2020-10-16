using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaCUNOR.Models
{
    public class RecoveryViewModel
    {
        [Required(ErrorMessage = "Es Necesario la Contraseña")]
        [StringLength(255, ErrorMessage = "La contraseña debe tener entre 8  y 255 caracteres", MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "La contraseña debe tener 8 caracteres como minimo")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Es necesario Confirmar la Contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coiciden")]
        public string Password2 { get; set; }


        public string token { get; set; }
    }
}

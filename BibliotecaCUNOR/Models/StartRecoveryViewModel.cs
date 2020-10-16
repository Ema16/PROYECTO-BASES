using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaCUNOR.Models
{
    public class StartRecoveryViewModel
    {
        [EmailAddress]
        [Required]
        public string CorreoElectornico { get; set; }
    }
}

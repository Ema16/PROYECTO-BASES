using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class RolUsuario
    {
        public RolUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int CodRolusuario { get; set; }
        public string Rol { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}

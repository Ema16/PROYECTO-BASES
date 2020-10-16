using System;
using System.Collections.Generic;

namespace BibliotecaCUNOR.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int CodTipousuario { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}

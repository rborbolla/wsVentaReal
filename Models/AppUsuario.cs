using System;
using System.Collections.Generic;

#nullable disable

namespace wsVentaReal.Models
{
    public partial class AppUsuario
    {
        public int? Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
    }
}

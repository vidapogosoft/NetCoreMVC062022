using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiDemo1.Modelos.Database
{
    public partial class Direcciones
    {
        public int IdDirecciones { get; set; }
        public int IdRegistrado { get; set; }
        public string Direccion { get; set; }
    }
}

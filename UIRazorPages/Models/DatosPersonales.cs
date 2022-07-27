using System;

namespace UIRazorPages.Models
{
    public class DatosPersonales
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Nacionalidad { get; set; }
        public string EstadoCivil { get; set; }
        public bool LicenciaConducir { get; set; }
        public bool MovilidadPropia { get; set; }
        public bool Discapacidad { get; set; }
    }
}

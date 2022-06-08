
using System.ComponentModel.DataAnnotations;

namespace ApiDemo1.Modelos.DTO
{
    public class DTOResultSet
    {
        [Key]
        public int Secuencial { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Nombres { get; set; }

    }
}

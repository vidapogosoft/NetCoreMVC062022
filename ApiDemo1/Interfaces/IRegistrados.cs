using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Modelos.Database;
using ApiDemo1.Modelos.DTO;

namespace ApiDemo1.Interfaces
{
    public interface IRegistrados
    {
        IEnumerable<Registrados> ListRegistrados { get; }

        IEnumerable<Registrados> ListRegistrado(string Identificacion);
        IEnumerable<Registrados> ListRegistradoById(int IdRegistrado);


        Registrados ListDatoRegistrado2(int IdRegistardo);

        void InsertRegistrado(Registrados New);
        
        void UpdateRegistrado(Registrados UpdItem);
        void UpdateRegistrado2(Registrados UpdItem);

        void DeleteRegistrado(Registrados DelItem);
        void DeleteRegistrado2(int idregistrado);


        IEnumerable<DTORegistrados> ListDTORegistrados { get; }

        IEnumerable<DTOResultSet> ListSPRegistrados { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Modelos.Database;

namespace ApiDemo1.Interfaces
{
    public interface IDireccion
    {
        void InsertDireccion(Direcciones New);

        IEnumerable<Direcciones> GetDireccionesByIdRegistrado(string IdRegistrado);
    }
}

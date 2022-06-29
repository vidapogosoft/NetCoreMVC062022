using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Interfaces;
using ApiDemo1.Modelos.Database;
using ApiDemo1.DataRepository;

namespace ApiDemo1.Services
{
    public class ServiceDirecciones : IDireccion
    {
        public DataDirecciones data = new DataDirecciones();

        public void InsertDireccion(Direcciones New)
        {
            data.InsertDireccion(New);
        }

        public IEnumerable<Direcciones> GetDireccionesByIdRegistrado(string IdRegistrado)
        {
            return data.GetDireccionesByIdRegistrado(IdRegistrado);
        }
    }
}

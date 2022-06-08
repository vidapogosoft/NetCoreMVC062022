using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Interfaces;
using ApiDemo1.Modelos.Database;
using ApiDemo1.Modelos.DTO;
using ApiDemo1.DataRepository;

namespace ApiDemo1.Services
{
    public class ServiceRegistrado : IRegistrados
    {
        public DataRegistrados data = new DataRegistrados();

        public IEnumerable<Registrados> ListRegistrados
        {
            get { return data.GetRegistrados(); }
        }

        public IEnumerable<Registrados> ListRegistrado(string Identificacion)
        {
            return data.GetRegistrado(Identificacion);
        }

        public IEnumerable<Registrados> ListRegistradoById(int IdRegistrado)
        {
            return data.GetRegistradoById(IdRegistrado);
        }


        public Registrados ListDatoRegistrado2(int IdRegistrado)
        {
            return data.GetDatoRegistradoById(IdRegistrado);
        }


        public void InsertRegistrado(Registrados New)
        {
            New.NombresCompletos = New.Nombres + ' ' + New.Apellidos;

            data.InsertRegistrado(New);
        }


        public void UpdateRegistrado(Registrados UpdItem)
        {
         
            data.UpdateRegistrado(UpdItem);
        }

        public void UpdateRegistrado2(Registrados UpdItem)
        {

            data.UpdateRegistrado2(UpdItem);
        }

        public void DeleteRegistrado(Registrados DelItem)
        {
            data.DeleteRegistrado(DelItem);
        }

        public void DeleteRegistrado2(int idregistrado)
        {
            data.DeleteRegistrado2(idregistrado);
        }

        public IEnumerable<DTORegistrados> ListDTORegistrados
        {
            get { return data.GetDTORegistrados(); }
        }

        public IEnumerable<DTOResultSet> ListSPRegistrados
        {
            get { return data.SPCargaRegistrados(); }
        }

    }   
}

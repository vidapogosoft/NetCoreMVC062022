using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Modelos.Database;
using ApiDemo1.Modelos.DTO;

using Microsoft.EntityFrameworkCore;

namespace ApiDemo1.DataRepository
{
    public class DataRegistrados
    {

        public List<Registrados> GetRegistrados()
        {

            using (var context = new DBRegistradosContext())
            {
                return context.Registrados.ToList();
            }

        }

        public List<Registrados> GetRegistrado(string Identificacion)
        {

            using (var context = new DBRegistradosContext())
            {
                return context.Registrados.Where(a => a.Identificacion == Identificacion)
                    .ToList();
            }

        }

        public List<Registrados> GetRegistradoById(int IdRegistrado)
        {

            using (var context = new DBRegistradosContext())
            {
                return context.Registrados.Where(a => a.IdRegistrado == IdRegistrado)
                    .ToList();
            }

        }

        public Registrados GetDatoRegistradoById(int IdRegistrado)
        {
            using (var context = new DBRegistradosContext())
            {
                return context.Registrados.Where(a => a.IdRegistrado == IdRegistrado)
                    .FirstOrDefault();
            }

        }

        public void InsertRegistrado(Registrados NewItem)
        {
            using (var context = new DBRegistradosContext())
            {
                context.Registrados.Add(NewItem);
                context.SaveChanges();
            }
        }

        public void UpdateRegistrado(Registrados UpdItem)
        {
            using (var context = new DBRegistradosContext())
            {
                var registrado = context.Registrados.Where(a => a.IdRegistrado == UpdItem.IdRegistrado).ToList();

                if (registrado.Count > 0)
                {
                    foreach (Registrados reg in registrado)
                    {
                        reg.Identificacion = UpdItem.Identificacion;
                        reg.Nombres = UpdItem.Nombres;
                        reg.Apellidos = UpdItem.Apellidos;
                        reg.NombresCompletos = UpdItem.Nombres + " " + UpdItem.Apellidos;

                        context.SaveChanges();

                    }
                }

            }
        }


        public void UpdateRegistrado2(Registrados UpdItem)
        {
            using (var context = new DBRegistradosContext())
            {
                var registrado = context.Registrados.Where(a => a.IdRegistrado == UpdItem.IdRegistrado).FirstOrDefault();

                if (registrado != null)
                {

                    registrado.Identificacion = UpdItem.Identificacion;
                    registrado.Nombres = UpdItem.Nombres;
                    registrado.Apellidos = UpdItem.Apellidos;
                    registrado.NombresCompletos = UpdItem.Nombres + " " + UpdItem.Apellidos;

                    context.SaveChanges();

                }

            }
        }

        public void DeleteRegistrado(Registrados NewItem)
        {
            using (var context = new DBRegistradosContext())
            {
                context.Registrados.Remove(NewItem);
                context.SaveChanges();
            }
        }

        public void DeleteRegistrado2(int Idregistrado)
        {
            using (var context = new DBRegistradosContext())
            {
                var registrado = context.Registrados.Where(a => a.IdRegistrado == Idregistrado).FirstOrDefault();

                if (registrado != null)
                {
                    context.Registrados.Remove(registrado);

                    context.SaveChanges();

                }

            }
        }

        public List<DTORegistrados> GetDTORegistrados()
        {

            using (var context = new DBRegistradosContext())
            {

                var x = (

                    from a in context.Registrados

                    select new DTORegistrados()
                    {
                        IdSecuencial = a.IdRegistrado,
                        DatosRegistrados = a.Identificacion + "-" + a.NombresCompletos
                    }

                    ).ToList();

                return x;
            }
        }

        public List<DTOResultSet> SPCargaRegistrados()
        {

            using (var context = new DBRegistradosContext())
            {

                return context.Resultado.FromSqlRaw("SPCargaRegistrados").ToList(); 

            }

        }

        public List<DTOResultSet> SPCargaRegistrados2(int IdRegistrado, string Identificacion)
        {

            using (var context = new DBRegistradosContext())
            {

                return context.Resultado.FromSqlRaw("SPCargaRegistrados {0},{1}", IdRegistrado, Identificacion)
                    .ToList();

            }

        }


    }
}

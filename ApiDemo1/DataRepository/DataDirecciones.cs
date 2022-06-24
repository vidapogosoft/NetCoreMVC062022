﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Modelos.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiDemo1.DataRepository
{
    public class DataDirecciones
    {
        public void InsertDireccion(Direcciones NewItem)
        {
            using (var context = new DBRegistradosContext())
            {
                context.Direcciones.Add(NewItem);
                context.SaveChanges();
            }
        }
    }
}

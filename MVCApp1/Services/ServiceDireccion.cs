using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net.Http;
using MVCApp1.Models;

namespace MVCApp1.Services
{
    public class ServiceDireccion
    {
        //la implementacion del HTT Get

        List<Direcciones> direccion;
        HttpClient _Client;

        public ServiceDireccion()
        {
            _Client = new HttpClient();
        }

        public async Task<List<Direcciones>> GetDireccionesByIdRegistrado(string IdRegistrado)
        {
            var uriget = new Uri("http://localhost:3849/api/Registrado/" + IdRegistrado);


            direccion = new List<Direcciones>();


            var responseget = _Client.GetAsync(uriget).Result;

            if (responseget.IsSuccessStatusCode)
            {
                var contentget = await responseget.Content.ReadAsStringAsync();

                direccion = JsonConvert.DeserializeObject<List<Direcciones>>(contentget);

            }

            return direccion;


        }

    }
}

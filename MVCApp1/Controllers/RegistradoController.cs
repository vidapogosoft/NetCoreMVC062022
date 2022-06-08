using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

using MVCApp1.Models;

namespace MVCApp1.Controllers
{
    public class RegistradoController : Controller
    {
        string Baseurl = "http://localhost:3849/";

        // GET: RegistradoController
        public async Task<ActionResult> Index()
        {
            var ListRegistrados = new List<Registrado>();

            //Lleno la lista
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Registrado/");

                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;

                    ListRegistrados = JsonConvert.DeserializeObject<List<Registrado>>(Response);
                }


            }

            return View(ListRegistrados);
            
        }

        // GET: RegistradoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistradoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistradoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistradoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistradoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistradoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistradoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCApp1.Models;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace MVCApp1.Controllers
{
    public class DireccionController : Controller
    {
        string Baseurl = "http://localhost:3849/";

        // GET: DireccionController
        public ActionResult Index(Registrado model)
        {
          
            return View(model);
        }

        // GET: DireccionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DireccionController/Create
        public ActionResult Create(string Idregistrado)
        {
            ViewBag.id = Idregistrado;
            return View();
        }

        // POST: DireccionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Direcciones collection)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var json = JsonConvert.SerializeObject(collection);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage Res = client.PostAsync("api/Direccion", content).GetAwaiter().GetResult();

                    if (Res.IsSuccessStatusCode)
                    {
                        var RegResponse = Res.Content.ReadAsStringAsync().Result;
                    }

                }

                return RedirectToAction("Index", "Registrado");
            }
            catch
            {
                return View();
            }
        }

        // GET: DireccionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DireccionController/Edit/5
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

        // GET: DireccionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DireccionController/Delete/5
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

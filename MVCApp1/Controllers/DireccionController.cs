﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCApp1.Models;

namespace MVCApp1.Controllers
{
    public class DireccionController : Controller
    {
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: DireccionController/Create
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

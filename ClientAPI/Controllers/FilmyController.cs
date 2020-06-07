using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientAPI.Models;
using ClientAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClientAPI.Controllers
{
    public class FilmyController : Controller
    {
        private IAPIService _service;

        public FilmyController(IAPIService service)
        {
            _service = service;
        }
        
        // GET: FilmyController
        public async Task<ActionResult> Index()
        {
            List<Film> filmy = new List<Film>();
            var response = await _service.Client.GetAsync("/api/Films");
            if (response.IsSuccessStatusCode)
            {
                var pobranefilmy = response.Content.ReadAsStringAsync().Result;
                filmy = JsonConvert.DeserializeObject<List<Film>>(pobranefilmy);
            }

            return View(filmy);
        }

        // GET: FilmyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FilmyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmyController/Create
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

        // GET: FilmyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilmyController/Edit/5
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

        // GET: FilmyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FilmyController/Delete/5
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

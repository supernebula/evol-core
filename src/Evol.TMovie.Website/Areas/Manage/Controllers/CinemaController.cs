using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Evol.TMovie.Website.Areas.Manage.Controllers
{

    [Area("Manage")]
    public class CinemaController : Controller
    {
        // GET: Cinema
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cinema/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cinema/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cinema/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cinema/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cinema/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cinema/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cinema/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
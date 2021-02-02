using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yarn_Feed.Controllers
{
    public class CraftersController : Controller
    {
        // GET: CraftersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CraftersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CraftersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CraftersController/Create
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

        // GET: CraftersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CraftersController/Edit/5
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

        // GET: CraftersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CraftersController/Delete/5
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

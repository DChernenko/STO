using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STO.WebUI.Controllers
{
    public class TypeCarController : Controller
    {
        // GET: TypeCar
        public ActionResult Index()
        {
            return View();
        }

        // GET: TypeCar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TypeCar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeCar/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: TypeCar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TypeCar/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: TypeCar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TypeCar/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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

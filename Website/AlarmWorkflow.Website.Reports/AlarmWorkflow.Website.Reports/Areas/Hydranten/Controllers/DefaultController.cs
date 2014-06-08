using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlarmWorkflow.Website.Reports.Areas.Hydranten.Models;

namespace AlarmWorkflow.Website.Reports.Areas.Hydranten.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Hydranten/Default/

        public ActionResult Index()
        {
            List<HydrantModel> hydranten = new List<HydrantModel>();
            return View(hydranten);
        }

        //
        // GET: /Hydranten/Default/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Hydranten/Default/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Hydranten/Default/Create

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

        //
        // GET: /Hydranten/Default/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Hydranten/Default/Edit/5

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

        //
        // GET: /Hydranten/Default/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Hydranten/Default/Delete/5

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

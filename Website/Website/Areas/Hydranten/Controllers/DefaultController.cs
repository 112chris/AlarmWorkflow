using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlarmWorkflow.Website.Reports.Areas.Hydranten.Models;
using AlarmWorkflow.Website.Reports.Filters;

namespace AlarmWorkflow.Website.Reports.Areas.Hydranten.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Hydranten/Default/

        public ActionResult Index()
        {
            using (HydrantenContext context = new HydrantenContext())
            {
                return View(context.hydrantens.ToList());
            }
        }

        //
        // GET: /Hydranten/Default/Details/5

        public ActionResult Details(int id)
        {
            using (HydrantenContext context = new HydrantenContext())
            {
                context.hydrant_ergebnis.Load();
                context.hydrant_lage.Load();
                return View(context.hydrantens.FirstOrDefault(x => x.ID == id));
            }
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
        public ActionResult Create(Hydrant model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (HydrantenContext context = new HydrantenContext())
                    {
                        context.hydrantens.AddOrUpdate(model);
                        context.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View(model);
            }
        }

        //
        // GET: /Hydranten/Default/Edit/5

        public ActionResult Edit(int id)
        {
            using (HydrantenContext context = new HydrantenContext())
            {
                context.hydrant_ergebnis.Load();
                context.hydrant_lage.Load();
                return View(context.hydrantens.FirstOrDefault(x => x.ID == id));
            }
        }

        //
        // POST: /Hydranten/Default/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Hydrant model)
        {
            try
            {
                using (HydrantenContext context = new HydrantenContext())
                {
                    context.hydrantens.AddOrUpdate(model);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException)
                {
                    var errors = (ex as DbEntityValidationException).EntityValidationErrors;
                }
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
        public ActionResult Delete(int id, Hydrant model)
        {
            try
            {
                using (HydrantenContext context = new HydrantenContext())
                {
                    context.hydrantens.Remove(context.hydrantens.First(x => x.ID == id));
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

// This file is part of AlarmWorkflow.
// 
// AlarmWorkflow is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// AlarmWorkflow is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with AlarmWorkflow.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using AlarmWorkflow.Website.Reports.Areas.Hydranten.Models;
using AlarmWorkflow.Website.Reports.Filters;
using Microsoft.Win32;

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
                if (model.UploadFile != null)
                {
                    string mapPath = Server.MapPath("~/upload/");
                    if (!Directory.Exists(mapPath))
                    {
                        Directory.CreateDirectory(mapPath);
                    }
                    model.UploadFile.SaveAs(Path.Combine(mapPath, model.UploadFile.FileName));
                    model.ImagePath = model.UploadFile.FileName;
                }
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
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult GetImage(int id)
        {
            using (HydrantenContext context = new HydrantenContext())
            {
                Hydrant hydrant = context.hydrantens.FirstOrDefault(x => x.ID == id);
                if (hydrant == null || string.IsNullOrWhiteSpace(hydrant.ImagePath))
                {
                    return null;
                }
                else
                {
                    string mapPath = Server.MapPath("~/upload/");
                    return File(Path.Combine(mapPath, hydrant.ImagePath), GetMimeType(hydrant.ImagePath));
                }
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
            if (ModelState.IsValid)
            {
                if (model.UploadFile != null)
                {
                    string mapPath = Server.MapPath("~/upload/");
                    if (!Directory.Exists(mapPath))
                    {
                        Directory.CreateDirectory(mapPath);
                    }
                    model.UploadFile.SaveAs(Path.Combine(mapPath, model.UploadFile.FileName));
                    model.ImagePath = model.UploadFile.FileName;
                }
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
                    return View(model);
                }
            }
            else
            {
                return View(model);
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

        public ActionResult Search(string q)
        {
            if (q != null)
            {
                List<Hydrant> hydranten = SearchHydranten(q).ToList();
                return View("Index", hydranten);
            }
            SearchModel model = new SearchModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(SearchModel model)
        {
            List<Hydrant> hydranten = SearchHydranten(model.QueryString).ToList();

            return View("Index", hydranten);
        }

        public IEnumerable<Hydrant> SearchHydranten(string search)
        {
            using (HydrantenContext context = new HydrantenContext())
            {
                PropertyInfo[] properties = typeof(Hydrant).GetProperties();
                foreach (Hydrant hydrant in context.hydrantens)
                {
                    foreach (PropertyInfo property in properties)
                    {
                        object value;
                        try
                        {
                            value = property.GetValue(hydrant, null);
                        }
                        catch (Exception ex)
                        {
                            //Well in some properties I can't search ... go on and hope that I find a matching one!
                            continue;
                        }
                        if (value != null && Convert.ToString(value).Contains(search))
                        {
                            yield return hydrant;
                            break;
                        }
                    }
                }
            }
        }

        private static string GetMimeType(string path)
        {
            const string unkownMimeType = "application/unknown";
            RegistryKey regKey = Registry.ClassesRoot.OpenSubKey(Path.GetExtension(path).ToLower());

            if (regKey == null)
            {
                return unkownMimeType;
            }

            object contentType = regKey.GetValue("Content Type");

            return (contentType == null) ? unkownMimeType : contentType.ToString();
        }

    }
}

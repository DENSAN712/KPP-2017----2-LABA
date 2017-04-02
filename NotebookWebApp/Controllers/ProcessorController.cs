using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotebookWebApp.Models;

namespace NotebookWebApp.Controllers
{
    public class ProcessorController : Controller
    {
        private NotebookContext db = new NotebookContext();

        //
        // GET: /Processor/

        public ActionResult Index()
        {
            return View(db.Processors.ToList());
        }

        //
        // GET: /Processor/Details/5

        public ActionResult Details(int id = 0)
        {
            Processor processor = db.Processors.Find(id);
            if (processor == null)
            {
                return HttpNotFound();
            }
            return View(processor);
        }

        //
        // GET: /Processor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Processor/Create

        [HttpPost]
        public ActionResult Create(Processor processor)
        {
            if (ModelState.IsValid)
            {
                db.Processors.Add(processor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(processor);
        }

        //
        // GET: /Processor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Processor processor = db.Processors.Find(id);
            if (processor == null)
            {
                return HttpNotFound();
            }
            return View(processor);
        }

        //
        // POST: /Processor/Edit/5

        [HttpPost]
        public ActionResult Edit(Processor processor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(processor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(processor);
        }

        //
        // GET: /Processor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Processor processor = db.Processors.Find(id);
            if (processor == null)
            {
                return HttpNotFound();
            }
            return View(processor);
        }

        //
        // POST: /Processor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Processor processor = db.Processors.Find(id);
            db.Processors.Remove(processor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
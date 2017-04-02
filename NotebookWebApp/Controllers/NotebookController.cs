using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotebookWebApp.Models;
using NotebookWebApp.ViewModels;

namespace NotebookWebApp.Controllers
{
    public class NotebookController : Controller
    {
        private NotebookContext db = new NotebookContext();

        //
        // GET: /Notebook/

        public ActionResult Index()
        {
            return View(db.Notebooks.ToList());
        }

        //
        // GET: /Notebook/Details/5

        public ActionResult Details(int id = 0)
        {
            Notebook notebook = db.Notebooks.Find(id);
            if (notebook == null)
            {
                return HttpNotFound();
            }
            return View(notebook);
        }

        //
        // GET: /Notebook/Create

        public ActionResult Create()
        {
            var model = new NotebookViewModel();
            model.Notebook = new Notebook();

            IEnumerable<Manufacturer> manufacturers = db.Manufacturers;
            model.Manufacturers = from manufacturer in manufacturers
                                  select new SelectListItem { Text = manufacturer.Name, Value = manufacturer.ManufacturerID.ToString() };

            IEnumerable<Processor> processors = db.Processors;
            model.Processors = from processor in processors
                               select new SelectListItem { Text = processor.Model + " " + processor.Socket, Value = processor.ProcessorID.ToString() };

            IEnumerable<User> users = db.Users;
            model.Users = from user in users
                          select new SelectListItem { Text = user.Name, Value = user.UserID.ToString() };

            return View(model);
        }

        //
        // POST: /Notebook/Create

        [HttpPost]
        public ActionResult Create(Notebook notebook)
        {
            notebook.Manufacturer = db.Manufacturers.Find(notebook.Manufacturer.ManufacturerID);
            notebook.User = db.Users.Find(notebook.User.UserID);
            notebook.Processor = db.Processors.Find(notebook.Processor.ProcessorID);

            db.Notebooks.Add(notebook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Notebook/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Notebook notebook = db.Notebooks.Find(id);
            if (notebook == null)
            {
                return HttpNotFound();
            }
            return View(notebook);
        }

        //
        // POST: /Notebook/Edit/5

        [HttpPost]
        public ActionResult Edit(Notebook notebook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notebook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notebook);
        }

        //
        // GET: /Notebook/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Notebook notebook = db.Notebooks.Find(id);
            if (notebook == null)
            {
                return HttpNotFound();
            }
            return View(notebook);
        }

        //
        // POST: /Notebook/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Notebook notebook = db.Notebooks.Find(id);
            db.Notebooks.Remove(notebook);
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Comp2084_Assignment2.Models;

namespace Comp2084_Assignment2.Controllers
{
    public class ConsolesController : Controller
    {
        private GameListModel db = new GameListModel();

        // GET: Consoles
        public ActionResult Index()
        {
            return View(db.consoles.ToList());
        }

        // GET: Consoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            console console = db.consoles.Find(id);
            if (console == null)
            {
                return HttpNotFound();
            }
            return View(console);
        }

        // GET: Consoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,company,bio_link")] console console)
        {
            if (ModelState.IsValid)
            {
                db.consoles.Add(console);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(console);
        }

        // GET: Consoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            console console = db.consoles.Find(id);
            if (console == null)
            {
                return HttpNotFound();
            }
            return View(console);
        }

        // POST: Consoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,company,bio_link")] console console)
        {
            if (ModelState.IsValid)
            {
                db.Entry(console).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(console);
        }

        // GET: Consoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            console console = db.consoles.Find(id);
            if (console == null)
            {
                return HttpNotFound();
            }
            return View(console);
        }

        // POST: Consoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            console console = db.consoles.Find(id);
            db.consoles.Remove(console);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

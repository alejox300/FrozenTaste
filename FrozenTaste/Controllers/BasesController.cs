using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FrozenTaste.Models;

namespace FrozenTaste.Controllers
{
    public class BasesController : Controller
    {
        private FrozenTasteContext db = new FrozenTasteContext();

        // GET: Bases
        public ActionResult Index()
        {
            return View(db.Bases.ToList());
        }

        // GET: Bases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bases bases = db.Bases.Find(id);
            if (bases == null)
            {
                return HttpNotFound();
            }
            return View(bases);
        }

        // GET: Bases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bases/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Base,Base")] Bases bases)
        {
            if (ModelState.IsValid)
            {
                db.Bases.Add(bases);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bases);
        }

        // GET: Bases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bases bases = db.Bases.Find(id);
            if (bases == null)
            {
                return HttpNotFound();
            }
            return View(bases);
        }

        // POST: Bases/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Base,Base")] Bases bases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bases);
        }

        // GET: Bases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bases bases = db.Bases.Find(id);
            if (bases == null)
            {
                return HttpNotFound();
            }
            return View(bases);
        }

        // POST: Bases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bases bases = db.Bases.Find(id);
            db.Bases.Remove(bases);
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

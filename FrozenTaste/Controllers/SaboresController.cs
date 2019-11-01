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
    public class SaboresController : Controller
    {
        private FrozenTasteContext db = new FrozenTasteContext();

        // GET: Sabores
        public ActionResult Index()
        {
            return View(db.Sabores.ToList());
        }

        // GET: Sabores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sabores sabores = db.Sabores.Find(id);
            if (sabores == null)
            {
                return HttpNotFound();
            }
            return View(sabores);
        }

        // GET: Sabores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sabores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Sabor,Sabor")] Sabores sabores)
        {
            if (ModelState.IsValid)
            {
                db.Sabores.Add(sabores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sabores);
        }

        // GET: Sabores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sabores sabores = db.Sabores.Find(id);
            if (sabores == null)
            {
                return HttpNotFound();
            }
            return View(sabores);
        }

        // POST: Sabores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Sabor,Sabor")] Sabores sabores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sabores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sabores);
        }

        // GET: Sabores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sabores sabores = db.Sabores.Find(id);
            if (sabores == null)
            {
                return HttpNotFound();
            }
            return View(sabores);
        }

        // POST: Sabores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sabores sabores = db.Sabores.Find(id);
            db.Sabores.Remove(sabores);
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

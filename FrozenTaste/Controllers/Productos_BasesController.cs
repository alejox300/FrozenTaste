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
    public class Productos_BasesController : Controller
    {
        private FrozenTasteContext db = new FrozenTasteContext();

        // GET: Productos_Bases
        public ActionResult Index()
        {
            var productos_Bases = db.Productos_Bases.Include(p => p.Bases).Include(p => p.Productos);
            return View(productos_Bases.ToList());
        }

        // GET: Productos_Bases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos_Bases productos_Bases = db.Productos_Bases.Find(id);
            if (productos_Bases == null)
            {
                return HttpNotFound();
            }
            return View(productos_Bases);
        }

        // GET: Productos_Bases/Create
        public ActionResult Create()
        {
            ViewBag.Id_Base = new SelectList(db.Bases, "Id_Base", "Base");
            ViewBag.Id_Producto = new SelectList(db.Productos, "Id_Producto", "Producto");
            return View();
        }

        // POST: Productos_Bases/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Productos_Base,Id_Producto,Id_Base")] Productos_Bases productos_Bases)
        {
            if (ModelState.IsValid)
            {
                db.Productos_Bases.Add(productos_Bases);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Base = new SelectList(db.Bases, "Id_Base", "Base", productos_Bases.Id_Base);
            ViewBag.Id_Producto = new SelectList(db.Productos, "Id_Producto", "Producto", productos_Bases.Id_Producto);
            return View(productos_Bases);
        }

        // GET: Productos_Bases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos_Bases productos_Bases = db.Productos_Bases.Find(id);
            if (productos_Bases == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Base = new SelectList(db.Bases, "Id_Base", "Base", productos_Bases.Id_Base);
            ViewBag.Id_Producto = new SelectList(db.Productos, "Id_Producto", "Producto", productos_Bases.Id_Producto);
            return View(productos_Bases);
        }

        // POST: Productos_Bases/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Productos_Base,Id_Producto,Id_Base")] Productos_Bases productos_Bases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos_Bases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Base = new SelectList(db.Bases, "Id_Base", "Base", productos_Bases.Id_Base);
            ViewBag.Id_Producto = new SelectList(db.Productos, "Id_Producto", "Producto", productos_Bases.Id_Producto);
            return View(productos_Bases);
        }

        // GET: Productos_Bases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos_Bases productos_Bases = db.Productos_Bases.Find(id);
            if (productos_Bases == null)
            {
                return HttpNotFound();
            }
            return View(productos_Bases);
        }

        // POST: Productos_Bases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos_Bases productos_Bases = db.Productos_Bases.Find(id);
            db.Productos_Bases.Remove(productos_Bases);
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

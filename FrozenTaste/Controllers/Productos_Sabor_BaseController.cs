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
    public class Productos_Sabor_BaseController : Controller
    {
        private FrozenTasteContext db = new FrozenTasteContext();

        // GET: Productos_Sabor_Base
        public ActionResult Index()
        {
            var productos_Sabor_Base = db.Productos_Sabor_Base.Include(p => p.Bases).Include(p => p.Productos).Include(p => p.Sabores);
            return View(productos_Sabor_Base.ToList());
        }

        // GET: Productos_Sabor_Base/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos_Sabor_Base productos_Sabor_Base = db.Productos_Sabor_Base.Find(id);
            if (productos_Sabor_Base == null)
            {
                return HttpNotFound();
            }
            return View(productos_Sabor_Base);
        }

        // GET: Productos_Sabor_Base/Create
        public ActionResult Create()
        {
            ViewBag.Id_Base = new SelectList(db.Bases, "Id_Base", "Base");
            ViewBag.Id_Producto = new SelectList(db.Productos, "Id_Producto", "Producto");
            ViewBag.Id_Sabor = new SelectList(db.Sabores, "Id_Sabor", "Sabor");
            return View();
        }

        // POST: Productos_Sabor_Base/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Productos_Sabor_Base,Id_Producto,Id_Sabor,Id_Base")] Productos_Sabor_Base productos_Sabor_Base)
        {
            if (ModelState.IsValid)
            {
                db.Productos_Sabor_Base.Add(productos_Sabor_Base);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Base = new SelectList(db.Bases, "Id_Base", "Base", productos_Sabor_Base.Id_Base);
            ViewBag.Id_Producto = new SelectList(db.Productos, "Id_Producto", "Producto", productos_Sabor_Base.Id_Producto);
            ViewBag.Id_Sabor = new SelectList(db.Sabores, "Id_Sabor", "Sabor", productos_Sabor_Base.Id_Sabor);
            return View(productos_Sabor_Base);
        }

        // GET: Productos_Sabor_Base/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos_Sabor_Base productos_Sabor_Base = db.Productos_Sabor_Base.Find(id);
            if (productos_Sabor_Base == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Base = new SelectList(db.Bases, "Id_Base", "Base", productos_Sabor_Base.Id_Base);
            ViewBag.Id_Producto = new SelectList(db.Productos, "Id_Producto", "Producto", productos_Sabor_Base.Id_Producto);
            ViewBag.Id_Sabor = new SelectList(db.Sabores, "Id_Sabor", "Sabor", productos_Sabor_Base.Id_Sabor);
            return View(productos_Sabor_Base);
        }

        // POST: Productos_Sabor_Base/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Productos_Sabor_Base,Id_Producto,Id_Sabor,Id_Base")] Productos_Sabor_Base productos_Sabor_Base)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos_Sabor_Base).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Base = new SelectList(db.Bases, "Id_Base", "Base", productos_Sabor_Base.Id_Base);
            ViewBag.Id_Producto = new SelectList(db.Productos, "Id_Producto", "Producto", productos_Sabor_Base.Id_Producto);
            ViewBag.Id_Sabor = new SelectList(db.Sabores, "Id_Sabor", "Sabor", productos_Sabor_Base.Id_Sabor);
            return View(productos_Sabor_Base);
        }

        // GET: Productos_Sabor_Base/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos_Sabor_Base productos_Sabor_Base = db.Productos_Sabor_Base.Find(id);
            if (productos_Sabor_Base == null)
            {
                return HttpNotFound();
            }
            return View(productos_Sabor_Base);
        }

        // POST: Productos_Sabor_Base/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos_Sabor_Base productos_Sabor_Base = db.Productos_Sabor_Base.Find(id);
            db.Productos_Sabor_Base.Remove(productos_Sabor_Base);
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

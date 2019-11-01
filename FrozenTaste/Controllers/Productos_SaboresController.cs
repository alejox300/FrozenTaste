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
    public class Productos_SaboresController : Controller
    {
        private FrozenTasteContext db = new FrozenTasteContext();

        // GET: Productos_Sabores
        public ActionResult Index()
        {
            var productos_Sabores = db.Productos_Sabores.Include(p => p.Productos).Include(p => p.Sabores);
            return View(productos_Sabores.ToList());
        }

        // GET: Productos_Sabores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos_Sabores productos_Sabores = db.Productos_Sabores.Find(id);
            if (productos_Sabores == null)
            {
                return HttpNotFound();
            }
            return View(productos_Sabores);
        }

        // GET: Productos_Sabores/Create
        public ActionResult Create()
        {
            ViewBag.Id_Producto = new SelectList(db.Productos, "Id_Producto", "Producto");
            ViewBag.Id_Sabor = new SelectList(db.Sabores, "Id_Sabor", "Sabor");
            return View();
        }

        // POST: Productos_Sabores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Productos_Sabor,Id_Producto,Id_Sabor")] Productos_Sabores productos_Sabores)
        {
            if (ModelState.IsValid)
            {
                db.Productos_Sabores.Add(productos_Sabores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Producto = new SelectList(db.Productos, "Id_Producto", "Producto", productos_Sabores.Id_Producto);
            ViewBag.Id_Sabor = new SelectList(db.Sabores, "Id_Sabor", "Sabor", productos_Sabores.Id_Sabor);
            return View(productos_Sabores);
        }

        // GET: Productos_Sabores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos_Sabores productos_Sabores = db.Productos_Sabores.Find(id);
            if (productos_Sabores == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Producto = new SelectList(db.Productos, "Id_Producto", "Producto", productos_Sabores.Id_Producto);
            ViewBag.Id_Sabor = new SelectList(db.Sabores, "Id_Sabor", "Sabor", productos_Sabores.Id_Sabor);
            return View(productos_Sabores);
        }

        // POST: Productos_Sabores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Productos_Sabor,Id_Producto,Id_Sabor")] Productos_Sabores productos_Sabores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos_Sabores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Producto = new SelectList(db.Productos, "Id_Producto", "Producto", productos_Sabores.Id_Producto);
            ViewBag.Id_Sabor = new SelectList(db.Sabores, "Id_Sabor", "Sabor", productos_Sabores.Id_Sabor);
            return View(productos_Sabores);
        }

        // GET: Productos_Sabores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos_Sabores productos_Sabores = db.Productos_Sabores.Find(id);
            if (productos_Sabores == null)
            {
                return HttpNotFound();
            }
            return View(productos_Sabores);
        }

        // POST: Productos_Sabores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos_Sabores productos_Sabores = db.Productos_Sabores.Find(id);
            db.Productos_Sabores.Remove(productos_Sabores);
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

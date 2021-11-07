using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebRepuestosOrellana.Models;

namespace WebRepuestosOrellana.Controllers
{
    [Authorize]
    public class TipoProductosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoProductos
        public ActionResult Index()
        {
            return View(db.TipoProductos.ToList());
        }

        // GET: TipoProductos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProducto tipoProducto = db.TipoProductos.Find(id);
            if (tipoProducto == null)
            {
                return HttpNotFound();
            }
            return View(tipoProducto);
        }

        // GET: TipoProductos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoProductos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Descripcion")] TipoProducto tipoProducto)
        {
            if (ModelState.IsValid)
            {
                db.TipoProductos.Add(tipoProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoProducto);
        }

        // GET: TipoProductos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProducto tipoProducto = db.TipoProductos.Find(id);
            if (tipoProducto == null)
            {
                return HttpNotFound();
            }
            return View(tipoProducto);
        }

        // POST: TipoProductos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descripcion")] TipoProducto tipoProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoProducto);
        }

        // GET: TipoProductos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProducto tipoProducto = db.TipoProductos.Find(id);
            if (tipoProducto == null)
            {
                return HttpNotFound();
            }
            return View(tipoProducto);
        }

        // POST: TipoProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoProducto tipoProducto = db.TipoProductos.Find(id);
            db.TipoProductos.Remove(tipoProducto);
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

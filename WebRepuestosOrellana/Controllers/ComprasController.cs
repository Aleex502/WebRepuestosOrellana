using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebRepuestosOrellana.Models;
using WebRepuestosOrellana.Models.ViewModels;

namespace WebRepuestosOrellana.Controllers
{
    [Authorize]
    public class ComprasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Compras
        public ActionResult Index()
        {
            var compras = db.Compras.Include(c => c.Proveedor);
            return View(compras.ToList());
        }

        // GET: Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras
                .Include(v => v.Usuario)
                .Include(v => v.Proveedor)
                .Include(v => v.CompraLineas)
                .FirstOrDefault(x => x.ID == id);

            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            ViewBag.ProveedorID = new SelectList(db.Proveedors, "ID", "Nombre");
            ViewBag.Productos = new SelectList(db.Productos, "ID", "Descripcion").Prepend(new SelectListItem()
            {
                Text = "",
                Value = "",
            });
            return View();
        }

        // POST: Compras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(CompraViewModel model)
        {
            try
            {
                var idUsuario = User.Identity.GetUserId();
                Compra compra = new Compra();
                compra.UsuarioID = idUsuario;
                compra.FechaCreacion = DateTime.Now;
                compra.FechaFactura = model.FechaFactura;
                compra.SerieFactura = model.SerieFactura;
                compra.ProveedorID = model.ProveedorID;
                db.Compras.Add(compra);
                db.SaveChanges();

                foreach (var linea in model.lineasCompra)
                {
                    CompraLinea lineaCompra = new CompraLinea();
                    lineaCompra.NoLinea = linea.NoLinea;
                    lineaCompra.Precio = linea.Precio;
                    lineaCompra.ProductoID = linea.ProductoID;
                    lineaCompra.Cantidad = linea.Cantidad;
                    lineaCompra.CompraID = compra.ID;
                    db.CompraLineas.Add(lineaCompra);
                }

                db.SaveChanges();
                ViewBag.Message = "Registro insertado";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProveedorID = new SelectList(db.Proveedors, "ID", "Nombre", compra.ProveedorID);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FechaCreacion,FechaFactura,SerieFactura,ProveedorID,EmpleadoID")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProveedorID = new SelectList(db.Proveedors, "ID", "Nombre", compra.ProveedorID);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = db.Compras.Find(id);
            db.Compras.Remove(compra);
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

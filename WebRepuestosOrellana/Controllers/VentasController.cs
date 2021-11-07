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
    public class VentasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ventas
        public ActionResult Index()
        {
            var ventas = db.Ventas.Include(v => v.Cliente).Include(v => v.Usuario);
            return View(ventas.ToList());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas
                .Include(v => v.Usuario)
                .Include(v => v.Cliente)
                .Include(v => v.VentaLineas)
                .FirstOrDefault(x => x.ID == id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nombre");
            ViewBag.EmpleadoID = new SelectList(db.Empleados, "ID", "Usuario");
            ViewBag.Productos = new SelectList(db.Productos, "ID", "Descripcion").Prepend(new SelectListItem()
            {
                Text = "",
                Value = "",
            });
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(VentaViewModel model)
        {
            try
            {
                var idUsuario = User.Identity.GetUserId();
                Venta venta = new Venta();
                venta.UsuarioID = idUsuario;
                venta.FechaCreacion = DateTime.Now;
                venta.ClienteID = model.ClienteID;
                db.Ventas.Add(venta);
                db.SaveChanges();

                foreach (var linea in model.lineasVenta)
                {
                    VentaLinea lineaVenta = new VentaLinea();
                    lineaVenta.NoLinea = linea.NoLinea;
                    lineaVenta.Precio = linea.Precio;
                    lineaVenta.ProductoID = linea.ProductoID;
                    lineaVenta.Cantidad = linea.Cantidad;
                    lineaVenta.VentaID = venta.ID;
                    db.VentaLineas.Add(lineaVenta);
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

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nombre", venta.ClienteID);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FechaCreacion,ClienteID,EmpleadoID")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ID", "Nombre", venta.ClienteID);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = db.Ventas.Find(id);
            db.Ventas.Remove(venta);
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

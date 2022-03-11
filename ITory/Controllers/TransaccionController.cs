using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITory.Models;

namespace ITory.Controllers
{
    public class TransaccionController : Controller
    {
        private InventarioDBEntities db = new InventarioDBEntities();

        // GET: Transaccion
        public ActionResult Index()
        {
            var transaccion = db.Transaccion.Include(t => t.Articulo);
            return View(transaccion.ToList());
        }

        // GET: Transaccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: Transaccion/Create
        public ActionResult Create()
        {
            ViewBag.idArticulo = new SelectList(db.Articulo, "idArticulo", "Nombre");
            return View();
        }

        // POST: Transaccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTransaccion,Tipo,idArticulo,Fecha,Cantidad,Monto,Estado")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Transaccion.Add(transaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idArticulo = new SelectList(db.Articulo, "idArticulo", "Nombre", transaccion.idArticulo);
            return View(transaccion);
        }

        // GET: Transaccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idArticulo = new SelectList(db.Articulo, "idArticulo", "Nombre", transaccion.idArticulo);
            return View(transaccion);
        }

        // POST: Transaccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTransaccion,Tipo,idArticulo,Fecha,Cantidad,Monto,Estado")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idArticulo = new SelectList(db.Articulo, "idArticulo", "Nombre", transaccion.idArticulo);
            return View(transaccion);
        }

        // GET: Transaccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: Transaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaccion transaccion = db.Transaccion.Find(id);
            db.Transaccion.Remove(transaccion);
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

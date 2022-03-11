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
    public class Asiento_ContableController : Controller
    {
        private InventarioDBEntities db = new InventarioDBEntities();

        // GET: Asiento_Contable
        public ActionResult Index()
        {
            var asiento_Contable = db.Asiento_Contable.Include(a => a.Tipo_Inventario);
            return View(asiento_Contable.ToList());
        }

        // GET: Asiento_Contable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiento_Contable asiento_Contable = db.Asiento_Contable.Find(id);
            if (asiento_Contable == null)
            {
                return HttpNotFound();
            }
            return View(asiento_Contable);
        }

        // GET: Asiento_Contable/Create
        public ActionResult Create()
        {
            ViewBag.idTipoInventario = new SelectList(db.Tipo_Inventario, "idTipoInventario", "Nombre");
            return View();
        }

        // POST: Asiento_Contable/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAsiento,Descripcion,idTipoInventario,Cuenta_Contable,Tipo_Movimiento,Fecha_Asiento,Monto,Estado")] Asiento_Contable asiento_Contable)
        {
            if (ModelState.IsValid)
            {
                db.Asiento_Contable.Add(asiento_Contable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipoInventario = new SelectList(db.Tipo_Inventario, "idTipoInventario", "Nombre", asiento_Contable.idTipoInventario);
            return View(asiento_Contable);
        }

        // GET: Asiento_Contable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiento_Contable asiento_Contable = db.Asiento_Contable.Find(id);
            if (asiento_Contable == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipoInventario = new SelectList(db.Tipo_Inventario, "idTipoInventario", "Nombre", asiento_Contable.idTipoInventario);
            return View(asiento_Contable);
        }

        // POST: Asiento_Contable/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAsiento,Descripcion,idTipoInventario,Cuenta_Contable,Tipo_Movimiento,Fecha_Asiento,Monto,Estado")] Asiento_Contable asiento_Contable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiento_Contable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipoInventario = new SelectList(db.Tipo_Inventario, "idTipoInventario", "Nombre", asiento_Contable.idTipoInventario);
            return View(asiento_Contable);
        }

        // GET: Asiento_Contable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiento_Contable asiento_Contable = db.Asiento_Contable.Find(id);
            if (asiento_Contable == null)
            {
                return HttpNotFound();
            }
            return View(asiento_Contable);
        }

        // POST: Asiento_Contable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asiento_Contable asiento_Contable = db.Asiento_Contable.Find(id);
            db.Asiento_Contable.Remove(asiento_Contable);
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

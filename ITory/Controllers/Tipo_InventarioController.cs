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
    public class Tipo_InventarioController : Controller
    {
        private InventarioDBEntities db = new InventarioDBEntities();

        // GET: Tipo_Inventario
        public ActionResult Index()
        {
            return View(db.Tipo_Inventario.ToList());
        }

        // GET: Tipo_Inventario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Inventario tipo_Inventario = db.Tipo_Inventario.Find(id);
            if (tipo_Inventario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Inventario);
        }

        // GET: Tipo_Inventario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Inventario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoInventario,Nombre,Cuenta_Contable,Estado")] Tipo_Inventario tipo_Inventario)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Inventario.Add(tipo_Inventario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Inventario);
        }

        // GET: Tipo_Inventario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Inventario tipo_Inventario = db.Tipo_Inventario.Find(id);
            if (tipo_Inventario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Inventario);
        }

        // POST: Tipo_Inventario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoInventario,Nombre,Cuenta_Contable,Estado")] Tipo_Inventario tipo_Inventario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Inventario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Inventario);
        }

        // GET: Tipo_Inventario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Inventario tipo_Inventario = db.Tipo_Inventario.Find(id);
            if (tipo_Inventario == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Inventario);
        }

        // POST: Tipo_Inventario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Inventario tipo_Inventario = db.Tipo_Inventario.Find(id);
            db.Tipo_Inventario.Remove(tipo_Inventario);
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

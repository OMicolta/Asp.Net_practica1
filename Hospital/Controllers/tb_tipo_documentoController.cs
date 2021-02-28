using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospital.Data;

namespace Hospital.Controllers
{
    public class tb_tipo_documentoController : Controller
    {
        private HospitalDBEntities db = new HospitalDBEntities();

        // GET: tb_tipo_documento
        public ActionResult Index()
        {
            return View(db.tb_tipo_documento.ToList());
        }

        // GET: tb_tipo_documento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipo_documento tb_tipo_documento = db.tb_tipo_documento.Find(id);
            if (tb_tipo_documento == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipo_documento);
        }

        // GET: tb_tipo_documento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_tipo_documento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] tb_tipo_documento tb_tipo_documento)
        {
            if (ModelState.IsValid)
            {
                db.tb_tipo_documento.Add(tb_tipo_documento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_tipo_documento);
        }

        // GET: tb_tipo_documento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipo_documento tb_tipo_documento = db.tb_tipo_documento.Find(id);
            if (tb_tipo_documento == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipo_documento);
        }

        // POST: tb_tipo_documento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] tb_tipo_documento tb_tipo_documento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_tipo_documento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_tipo_documento);
        }

        // GET: tb_tipo_documento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipo_documento tb_tipo_documento = db.tb_tipo_documento.Find(id);
            if (tb_tipo_documento == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipo_documento);
        }

        // POST: tb_tipo_documento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_tipo_documento tb_tipo_documento = db.tb_tipo_documento.Find(id);
            db.tb_tipo_documento.Remove(tb_tipo_documento);
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

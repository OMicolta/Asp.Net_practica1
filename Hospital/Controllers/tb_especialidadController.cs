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
    public class tb_especialidadController : Controller
    {
        private HospitalDBEntities db = new HospitalDBEntities();

        // GET: tb_especialidad
        public ActionResult Index()
        {
            return View(db.tb_especialidad.ToList());
        }

        // GET: tb_especialidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_especialidad tb_especialidad = db.tb_especialidad.Find(id);
            if (tb_especialidad == null)
            {
                return HttpNotFound();
            }
            return View(tb_especialidad);
        }

        // GET: tb_especialidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_especialidad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] tb_especialidad tb_especialidad)
        {
            if (ModelState.IsValid)
            {
                db.tb_especialidad.Add(tb_especialidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_especialidad);
        }

        // GET: tb_especialidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_especialidad tb_especialidad = db.tb_especialidad.Find(id);
            if (tb_especialidad == null)
            {
                return HttpNotFound();
            }
            return View(tb_especialidad);
        }

        // POST: tb_especialidad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] tb_especialidad tb_especialidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_especialidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_especialidad);
        }

        // GET: tb_especialidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_especialidad tb_especialidad = db.tb_especialidad.Find(id);
            if (tb_especialidad == null)
            {
                return HttpNotFound();
            }
            return View(tb_especialidad);
        }

        // POST: tb_especialidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_especialidad tb_especialidad = db.tb_especialidad.Find(id);
            db.tb_especialidad.Remove(tb_especialidad);
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

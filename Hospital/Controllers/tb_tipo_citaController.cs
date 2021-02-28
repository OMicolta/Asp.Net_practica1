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
    public class tb_tipo_citaController : Controller
    {
        private HospitalDBEntities db = new HospitalDBEntities();

        // GET: tb_tipo_cita
        public ActionResult Index()
        {
            return View(db.tb_tipo_cita.ToList());
        }

        // GET: tb_tipo_cita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipo_cita tb_tipo_cita = db.tb_tipo_cita.Find(id);
            if (tb_tipo_cita == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipo_cita);
        }

        // GET: tb_tipo_cita/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_tipo_cita/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] tb_tipo_cita tb_tipo_cita)
        {
            if (ModelState.IsValid)
            {
                db.tb_tipo_cita.Add(tb_tipo_cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_tipo_cita);
        }

        // GET: tb_tipo_cita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipo_cita tb_tipo_cita = db.tb_tipo_cita.Find(id);
            if (tb_tipo_cita == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipo_cita);
        }

        // POST: tb_tipo_cita/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] tb_tipo_cita tb_tipo_cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_tipo_cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_tipo_cita);
        }

        // GET: tb_tipo_cita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipo_cita tb_tipo_cita = db.tb_tipo_cita.Find(id);
            if (tb_tipo_cita == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipo_cita);
        }

        // POST: tb_tipo_cita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_tipo_cita tb_tipo_cita = db.tb_tipo_cita.Find(id);
            db.tb_tipo_cita.Remove(tb_tipo_cita);
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

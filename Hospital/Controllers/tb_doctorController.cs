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
    public class tb_doctorController : Controller
    {
        private HospitalDBEntities db = new HospitalDBEntities();

        // GET: tb_doctor
        public ActionResult Index()
        {
            var tb_doctor = db.tb_doctor.Include(t => t.tb_especialidad).Include(t => t.tb_tipo_documento);
            return View(tb_doctor.ToList());
        }

        // GET: tb_doctor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_doctor tb_doctor = db.tb_doctor.Find(id);
            if (tb_doctor == null)
            {
                return HttpNotFound();
            }
            return View(tb_doctor);
        }

        // GET: tb_doctor/Create
        public ActionResult Create()
        {
            ViewBag.especialidad = new SelectList(db.tb_especialidad, "id", "nombre");
            ViewBag.tipoDocumento = new SelectList(db.tb_tipo_documento, "id", "nombre");
            return View();
        }

        // POST: tb_doctor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cedula,nombre,apellido,telefono,correo,tipoDocumento,especialidad")] tb_doctor tb_doctor)
        {
            if (ModelState.IsValid)
            {
                db.tb_doctor.Add(tb_doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.especialidad = new SelectList(db.tb_especialidad, "id", "nombre", tb_doctor.especialidad);
            ViewBag.tipoDocumento = new SelectList(db.tb_tipo_documento, "id", "nombre", tb_doctor.tipoDocumento);
            return View(tb_doctor);
        }

        // GET: tb_doctor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_doctor tb_doctor = db.tb_doctor.Find(id);
            if (tb_doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.especialidad = new SelectList(db.tb_especialidad, "id", "nombre", tb_doctor.especialidad);
            ViewBag.tipoDocumento = new SelectList(db.tb_tipo_documento, "id", "nombre", tb_doctor.tipoDocumento);
            return View(tb_doctor);
        }

        // POST: tb_doctor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cedula,nombre,apellido,telefono,correo,tipoDocumento,especialidad")] tb_doctor tb_doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.especialidad = new SelectList(db.tb_especialidad, "id", "nombre", tb_doctor.especialidad);
            ViewBag.tipoDocumento = new SelectList(db.tb_tipo_documento, "id", "nombre", tb_doctor.tipoDocumento);
            return View(tb_doctor);
        }

        // GET: tb_doctor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_doctor tb_doctor = db.tb_doctor.Find(id);
            if (tb_doctor == null)
            {
                return HttpNotFound();
            }
            return View(tb_doctor);
        }

        // POST: tb_doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_doctor tb_doctor = db.tb_doctor.Find(id);
            db.tb_doctor.Remove(tb_doctor);
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

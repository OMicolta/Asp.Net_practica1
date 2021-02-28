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
    public class tb_citaController : Controller
    {
        private HospitalDBEntities db = new HospitalDBEntities();

        // GET: tb_cita
        public ActionResult Index()
        {
            var tb_cita = db.tb_cita.Include(t => t.tb_doctor).Include(t => t.tb_paciente).Include(t => t.tb_tipo_cita);
            return View(tb_cita.ToList());
        }

        // GET: tb_cita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_cita tb_cita = db.tb_cita.Find(id);
            if (tb_cita == null)
            {
                return HttpNotFound();
            }
            return View(tb_cita);
        }

        // GET: tb_cita/Create
        public ActionResult Create()
        {
            ViewBag.doctorId = new SelectList(db.tb_doctor, "id", "cedula");
            ViewBag.pacienteId = new SelectList(db.tb_paciente, "id", "cedula");
            ViewBag.tipoCita = new SelectList(db.tb_tipo_cita, "id", "nombre");
            return View();
        }

        // POST: tb_cita/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,doctorId,pacienteId,tipoCita,fecha,hora,duracion")] tb_cita tb_cita)
        {
            if (ModelState.IsValid)
            {
                db.tb_cita.Add(tb_cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.doctorId = new SelectList(db.tb_doctor, "id", "cedula", tb_cita.doctorId);
            ViewBag.pacienteId = new SelectList(db.tb_paciente, "id", "cedula", tb_cita.pacienteId);
            ViewBag.tipoCita = new SelectList(db.tb_tipo_cita, "id", "nombre", tb_cita.tipoCita);
            return View(tb_cita);
        }

        // GET: tb_cita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_cita tb_cita = db.tb_cita.Find(id);
            if (tb_cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.doctorId = new SelectList(db.tb_doctor, "id", "cedula", tb_cita.doctorId);
            ViewBag.pacienteId = new SelectList(db.tb_paciente, "id", "cedula", tb_cita.pacienteId);
            ViewBag.tipoCita = new SelectList(db.tb_tipo_cita, "id", "nombre", tb_cita.tipoCita);
            return View(tb_cita);
        }

        // POST: tb_cita/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,doctorId,pacienteId,tipoCita,fecha,hora,duracion")] tb_cita tb_cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.doctorId = new SelectList(db.tb_doctor, "id", "cedula", tb_cita.doctorId);
            ViewBag.pacienteId = new SelectList(db.tb_paciente, "id", "cedula", tb_cita.pacienteId);
            ViewBag.tipoCita = new SelectList(db.tb_tipo_cita, "id", "nombre", tb_cita.tipoCita);
            return View(tb_cita);
        }

        // GET: tb_cita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_cita tb_cita = db.tb_cita.Find(id);
            if (tb_cita == null)
            {
                return HttpNotFound();
            }
            return View(tb_cita);
        }

        // POST: tb_cita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_cita tb_cita = db.tb_cita.Find(id);
            db.tb_cita.Remove(tb_cita);
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

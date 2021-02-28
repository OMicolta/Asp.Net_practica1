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
    public class tb_pacienteController : Controller
    {
        private HospitalDBEntities db = new HospitalDBEntities();

        // GET: tb_paciente
        public ActionResult Index()
        {
            var tb_paciente = db.tb_paciente.Include(t => t.tb_tipo_documento);
            return View(tb_paciente.ToList());
        }

        // GET: tb_paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_paciente tb_paciente = db.tb_paciente.Find(id);
            if (tb_paciente == null)
            {
                return HttpNotFound();
            }
            return View(tb_paciente);
        }

        // GET: tb_paciente/Create
        public ActionResult Create()
        {
            ViewBag.tipoDocumento = new SelectList(db.tb_tipo_documento, "id", "nombre");
            return View();
        }

        // POST: tb_paciente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cedula,nombre,apellido,telefono,correo,tipoDocumento")] tb_paciente tb_paciente)
        {
            if (ModelState.IsValid)
            {
                db.tb_paciente.Add(tb_paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipoDocumento = new SelectList(db.tb_tipo_documento, "id", "nombre", tb_paciente.tipoDocumento);
            return View(tb_paciente);
        }

        // GET: tb_paciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_paciente tb_paciente = db.tb_paciente.Find(id);
            if (tb_paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipoDocumento = new SelectList(db.tb_tipo_documento, "id", "nombre", tb_paciente.tipoDocumento);
            return View(tb_paciente);
        }

        // POST: tb_paciente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cedula,nombre,apellido,telefono,correo,tipoDocumento")] tb_paciente tb_paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipoDocumento = new SelectList(db.tb_tipo_documento, "id", "nombre", tb_paciente.tipoDocumento);
            return View(tb_paciente);
        }

        // GET: tb_paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_paciente tb_paciente = db.tb_paciente.Find(id);
            if (tb_paciente == null)
            {
                return HttpNotFound();
            }
            return View(tb_paciente);
        }

        // POST: tb_paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_paciente tb_paciente = db.tb_paciente.Find(id);
            db.tb_paciente.Remove(tb_paciente);
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

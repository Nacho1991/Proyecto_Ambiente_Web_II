using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using appProyectoFinal.Contexto;
using appProyectoFinal.Models;

namespace appProyectoFinal.Controllers
{
    public class PacientesController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Pacientes
        public ActionResult Index()
        {
            if (session())
            {
                return View(db.Pacientes.ToList());
            }
            else 
            {
                return RedirectToAction("Login");
            }
        }
        public Boolean session()
        {
            if (Request.Cookies["userName"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Paciente paciente = db.Pacientes.Find(id);
                if (paciente == null)
                {
                    return HttpNotFound();
                }
                return View(paciente);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            if (session())
            {
                return View();
            }
            else 
            {
                return RedirectToAction("Login");
            }
        }

        // POST: Pacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cedula,Nombre,Apellidos,Direccion,Contrasenna,tipoUsuario")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Pacientes.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Paciente paciente = db.Pacientes.Find(id);
                if (paciente == null)
                {
                    return HttpNotFound();
                }
                return View(paciente);
            }
            else {
                return RedirectToAction("Login");
            }
        }

        // POST: Pacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cedula,Nombre,Apellidos,Direccion,Contrasenna,tipoUsuario")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Paciente paciente = db.Pacientes.Find(id);
                if (paciente == null)
                {
                    return HttpNotFound();
                }
                return View(paciente);
            }
            else {
                return RedirectToAction("Login");
            }
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            db.Pacientes.Remove(paciente);
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

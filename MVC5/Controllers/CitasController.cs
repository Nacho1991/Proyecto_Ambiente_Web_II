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
    public class CitasController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: Citas
        public ActionResult Index()
        {
            if (session())
            {
                return View(db.Citas.ToList());
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
        // GET: Citas/Details/5
        public ActionResult Details(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cita cita = db.Citas.Find(id);
                if (cita == null)
                {
                    return HttpNotFound();
                }
                return View(cita);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Citas/Create
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

        // POST: Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fecha,Estado")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Citas.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cita);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cita cita = db.Citas.Find(id);
                if (cita == null)
                {
                    return HttpNotFound();
                }
                return View(cita);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // POST: Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fecha,Estado")] Cita cita)
        {
            if (session())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(cita).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(cita);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cita cita = db.Citas.Find(id);
                if (cita == null)
                {
                    return HttpNotFound();
                }
                return View(cita);
            }
            else {
                return RedirectToAction("Login");
            }
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cita cita = db.Citas.Find(id);
            db.Citas.Remove(cita);
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

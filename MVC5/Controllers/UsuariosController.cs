using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using appProyectoFinal.Contexto;
using System.Net;
using appProyectoFinal.Models;
using System.Data.Entity;
using System.Web.Helpers;
using System.Web.Security;

namespace appProyectoFinal.Controllers
{
    public class UsuariosController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

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
        // GET: Usuarios
        public ActionResult Index()
        {
            if (session())
            {
                return View(db.Usuarios.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Nombre_usuario,Contrasenna")] Usuario usuario)
        {
            if (IsValid(usuario.Nombre_Usuario, usuario.Contrasenna))
            {
                Response.Cookies["userName"].Value = usuario.Nombre_Usuario;
                Response.Cookies["userName"].Expires = DateTime.Now.AddDays(1);
                HttpCookie aCookie = new HttpCookie("lastVisit");
                aCookie.Value = DateTime.Now.ToString();
                aCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(aCookie);

                ViewData["Usuario"] = usuario.Nombre_Usuario;
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Usuario Incorrecto");
            }

            return RedirectToAction("Index");
        }
        public ActionResult Logout() {
            //Cerramos Session
            if (Request.Cookies["userName"] != null)
            {
                var c = new HttpCookie("userName");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
            return RedirectToAction("Login");
        }
        private bool IsValid(string user, string password)
        {
            bool isValid = false;
            var login = db.Usuarios.FirstOrDefault(usuario => usuario.Nombre_Usuario == user);
            if (login != null)
            {
                //var encrpPass = Crypto.Hash(password);
                if (login.Contrasenna == password)
                {
                    isValid = true;
                }
            }
            return isValid;
        }
        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuario usuario = db.Usuarios.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            if (session())
            {
                return View();
            }
            else {
                return RedirectToAction("Login");
            }
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Nombre_Usuario,Contrasenna")] Usuario pUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(pUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pUsuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuario usuario = db.Usuarios.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Nombre_Usuario,Contrasenna")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (session())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Usuario usuario = db.Usuarios.Find(id);
                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(usuario);
            }
            else 
            {
                return RedirectToAction("Login");
            }
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }

}

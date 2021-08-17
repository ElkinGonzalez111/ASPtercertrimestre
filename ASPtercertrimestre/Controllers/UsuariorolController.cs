using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPtercertrimestre.Models;

namespace ASPtercertrimestre.Controllers
{
    public class UsuariorolController : Controller
    {
        // GET: Usuariorol
        public ActionResult Index()
        {
            using (var db = new inventarioo2021Entities())
            {
                return View(db.usuariorol.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(usuariorol usuariorol)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventarioo2021Entities())
                {
                    db.usuariorol.Add(usuariorol);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }

        }

        public ActionResult Details(int id)
        {
            using (var db = new inventarioo2021Entities())
            {
                var findUser = db.usuariorol.Find(id);
                return View(findUser);
            }

        }

        public ActionResult Delete(int id)


        {
            try
            {
                using (var db = new inventarioo2021Entities())
                {
                    var finUser = db.usuariorol.Find(id);
                    db.usuariorol.Remove(finUser);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Edit(int id)


        {
            try
            {
                using (var db = new inventarioo2021Entities())
                {
                    usuariorol findUser = db.usuariorol.Where(a => a.id == id).FirstOrDefault();
                    return View(findUser);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(usuariorol editUser)
        {
            try
            {
                using (var db = new inventarioo2021Entities())
                {
                    usuariorol user = db.usuariorol.Find(editUser.id);

                    user.idUsuario = editUser.idUsuario;
                    user.idRol = editUser.idRol;

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
    }
}
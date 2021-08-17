using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPtercertrimestre.Models;

namespace ASPtercertrimestre.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            using (var db = new inventarioo2021Entities())
            {
                return View(db.compra.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(compra compra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventarioo2021Entities())
                {
                    db.compra.Add(compra);
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
                var findUser = db.compra.Find(id);
                return View(findUser);
            }

        }

        public ActionResult Delete(int id)


        {
            try
            {
                using (var db = new inventarioo2021Entities())
                {
                    var finUser = db.compra.Find(id);
                    db.compra.Remove(finUser);
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
                    compra findUser = db.compra.Where(a => a.id == id).FirstOrDefault();
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

        public ActionResult Edit(compra editUser)
        {
            try
            {
                using (var db = new inventarioo2021Entities())
                {
                    compra user = db.compra.Find(editUser.id);

                    user.id = editUser.id;
                    user.fecha = editUser.fecha;
                    user.total = editUser.total;
                    user.id_usuario = editUser.id_usuario;
                    user.id_cliente = editUser.id_cliente;

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
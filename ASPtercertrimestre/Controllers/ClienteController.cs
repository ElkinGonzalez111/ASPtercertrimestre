using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPtercertrimestre.Models;

namespace ASPtercertrimestre.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (var db = new inventarioo2021Entities())
            {
                return View(db.cliente.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(cliente cliente)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventarioo2021Entities())
                {
                    db.cliente.Add(cliente);
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
                var findUser = db.cliente.Find(id);
                return View(findUser);
            }

        }

        public ActionResult Delete(int id)


        {
            try
            {
                using (var db = new inventarioo2021Entities())
                {
                    var finUser = db.cliente.Find(id);
                    db.cliente.Remove(finUser);
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
                    cliente findUser = db.cliente.Where(a => a.id == id).FirstOrDefault();
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

        public ActionResult Edit(cliente editUser)
        {
            try
            {
                using (var db = new inventarioo2021Entities())
                {
                    cliente user = db.cliente.Find(editUser.id);

                    user.id = editUser.id;
                    user.nombre = editUser.nombre;
                    user.documento = editUser.documento;
                    user.email = editUser.email;


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
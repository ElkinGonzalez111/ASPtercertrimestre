using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPtercertrimestre.Models;

namespace ASPtercertrimestre.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            using (var db = new inventarioo2021Entities())
            {
                return View(db.producto.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(producto producto)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventarioo2021Entities())
                {
                    db.producto.Add(producto);
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
                var findUser = db.producto.Find(id);
                return View(findUser);
            }

        }

        public ActionResult Delete(int id)


        {
            try
            {
                using (var db = new inventarioo2021Entities())
                {
                    var finUser = db.producto.Find(id);
                    db.producto.Remove(finUser);
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
                    producto findUser = db.producto.Where(a => a.id == id).FirstOrDefault();
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

        public ActionResult Edit(producto editUser)
        {
            try
            {
                using (var db = new inventarioo2021Entities())
                {
                    producto user = db.producto.Find(editUser.id);

                    user.nombre = editUser.nombre;
                    user.id = editUser.id;
                    user.percio_unitario = editUser.percio_unitario;
                    user.descripcion = editUser.descripcion;
                    user.cantidad = editUser.cantidad;
                    user.id_proveedor = editUser.id_proveedor;

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
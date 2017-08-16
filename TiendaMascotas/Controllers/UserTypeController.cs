using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    public class UserTypeController : Controller
    {
        // GET: UserType
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getAllUserType()
        {
            try
            {
                if (Data.Data.UserTypes.Count>0) {
                    return Json(Data.Data.UserTypes, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: UserType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

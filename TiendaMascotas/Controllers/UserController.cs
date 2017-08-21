using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getAllUsers()
        {
            try
            {
                if (Data.Data.Users.Count > 0)
                {
                    return Json(Data.Data.Users, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddUser([Bind(Include = "Id, Name, LastName, PhoneNumber, Email, UserTypeId")] User pUser)
        {
            try
            {
                if (!string.IsNullOrEmpty(pUser.Name) && !string.IsNullOrEmpty(pUser.LastName) && !string.IsNullOrEmpty(pUser.Email) && !string.IsNullOrEmpty(pUser.PhoneNumber.ToString()))
                {
                    var lastUser = Data.Data.Users.LastOrDefault();
                    if (lastUser != null)
                    {
                        pUser.Id = lastUser.Id + 1;
                        Data.Data.Users.Add(pUser);
                        return Json(pUser, JsonRequestBehavior.AllowGet);
                    }

                    pUser.Id = 1;
                    Data.Data.Users.Add(pUser);
                    return Json(pUser, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult getUserById(int? userId)
        {
            try
            {
                if (userId!=null) {
                    var User = Data.Data.Users.Where(u => u.Id == userId).FirstOrDefault();

                    if (User!=null) {
                        return Json(User, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpDelete]
        public JsonResult RemoveUser(int? userId)
        {
            try
            {
                var _user = Data.Data.Users.Where(f => f.Id == userId).FirstOrDefault();
                if (_user != null)
                {
                    Data.Data.Users.Remove(_user);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPut]
        public JsonResult UpdateUser([Bind(Include = "Id, Name, LastName, PhoneNumber, Email, UserTypeId")] User pUser)
        {
            try
            {
                if (!string.IsNullOrEmpty(pUser.Id.ToString()) && !string.IsNullOrEmpty(pUser.Name) && !string.IsNullOrEmpty(pUser.LastName) && !string.IsNullOrEmpty(pUser.Email) && !string.IsNullOrEmpty(pUser.PhoneNumber.ToString()))
                {
                    var foundUser = Data.Data.Users.Where(u => u.Id == pUser.Id).FirstOrDefault();
                    if (foundUser != null)
                    {
                        foundUser.Name = pUser.Name;
                        foundUser.LastName = pUser.LastName;
                        foundUser.PhoneNumber = pUser.PhoneNumber;
                        foundUser.Email = pUser.Email;
                        foundUser.UserTypeId = pUser.UserTypeId;
                        return Json(foundUser, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        //// GET: User/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: User/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: User/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: User/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: User/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: User/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: User/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

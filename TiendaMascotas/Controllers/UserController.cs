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

        [HttpPost]
        public JsonResult AddUser([Bind(Include = "Name,LastName,Mail,PhoneNumber,IdUserType")] User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.LastName) && !string.IsNullOrEmpty(user.Mail) && !string.IsNullOrEmpty(user.PhoneNumber.ToString()))
                {
                    var lastUser = Data.Data.UserList.LastOrDefault();
                    if (lastUser == null)
                    {
                        user.Id = 1;
                        Data.Data.UserList.Add(user);
                        return Json(user, JsonRequestBehavior.AllowGet);
                    }
                    user.Id = lastUser.Id + 1;
                    Data.Data.UserList.Add(user);
                    return Json(user, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpDelete]
        public JsonResult RemoveUser(int? userId)
        {
            try
            {
                var user = Data.Data.UserList.Where(f => f.Id == userId).FirstOrDefault();
                if (user != null)
                {
                    Data.Data.UserList.Remove(user);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPut]
        public JsonResult UpdateUser([Bind(Include = "Id,Name,LastName,Mail,PhoneNumber,IdUserType")] User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Id.ToString()) && !string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.LastName) && !string.IsNullOrEmpty(user.Mail) && !string.IsNullOrEmpty(user.PhoneNumber.ToString()))
                {
                    var foundUser = Data.Data.UserList.Where(s => s.Id == user.Id).FirstOrDefault();
                    if (foundUser != null)
                    {
                        foundUser.Name = user.Name;
                        foundUser.LastName = user.LastName;
                        foundUser.Mail = user.Mail;
                        foundUser.PhoneNumber = user.PhoneNumber;
                        foundUser.IdUserType = user.IdUserType;
                        return Json(foundUser, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            try
            {
                return Json(Data.Data.UserList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

    }
}
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

        public JsonResult getUserNameById(int? userId)
        {
            try
            {
                if (userId != null)
                {
                    var UserName = Data.Data.Users.Where(u => u.Id == userId).FirstOrDefault();

                    if (UserName != null)
                    {
                        return Json(UserName, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult AddUser([Bind(Include = "Name,LastName,Mail,PhoneNumber,IdUserType")] User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.LastName) && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Phone.ToString()))
                {
                    var lastUser = Data.Data.Users.LastOrDefault();
                    if (lastUser == null)
                    {
                        user.Id = 1;
                        Data.Data.Users.Add(user);
                        return Json(user, JsonRequestBehavior.AllowGet);
                    }
                    user.Id = lastUser.Id + 1;
                    Data.Data.Users.Add(user);
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
                var user = Data.Data.Users.Where(f => f.Id == userId).FirstOrDefault();
                if (user != null)
                {
                    Data.Data.Users.Remove(user);
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
                if (!string.IsNullOrEmpty(user.Id.ToString()) && !string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.LastName) && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Phone.ToString()))
                {
                    var foundUser = Data.Data.Users.Where(s => s.Id == user.Id).FirstOrDefault();
                    if (foundUser != null)
                    {
                        foundUser.Name = user.Name;
                        foundUser.LastName = user.LastName;
                        foundUser.Email = user.Email;
                        foundUser.Phone = user.Phone;
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
    }
}
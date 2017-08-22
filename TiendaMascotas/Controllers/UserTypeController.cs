using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                if (Data.Data.UserTypes.Count > 0)
                {
                    return Json(Data.Data.UserTypes, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetUserTypeById(int userTypeId)
        {
            try
            {
                return Json(Data.Data.UserTypes.Where(p => p.Id == userTypeId).FirstOrDefault(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
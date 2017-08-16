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

        [HttpGet]
        public JsonResult GetAllUserType()
        {
            try
            {
                return Json(Data.Data.UserTypeList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetUserTypeById(int userTypeId)
        {
            try
            {
                return Json(Data.Data.UserTypeList.Where(p => p.Id == userTypeId).FirstOrDefault(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
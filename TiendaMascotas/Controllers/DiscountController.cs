using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaMascotas.Controllers
{
    public class DiscountController : Controller
    {
        // GET: Discount
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllDiscount()
        {
            try
            {
                return Json(Data.Data.DiscountList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetDiscountById(int? BillId)
        {
            try
            {
                if (BillId != null)
                {
                    return Json(Data.Data.DiscountList.Where(p => p.Id == BillId).FirstOrDefault(), JsonRequestBehavior.AllowGet);
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
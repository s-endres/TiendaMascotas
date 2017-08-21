using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getBill(int? BillId)
        {
            try
            {
                if (BillId != null)
                {
                    var bill = Data.Data.BillList.Where(p => p.Id == BillId).FirstOrDefault();
                    if (bill != null)
                    {
                        return Json(bill, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
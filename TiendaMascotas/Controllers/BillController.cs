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

        [HttpPost]
        public JsonResult AddBill([Bind(Include = "IdUser, Code, Date")] Bill Bill)
        {

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetallBills()
        {
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult UpdateBill()
        {
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.Data;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    public class ProductTypeController : Controller
    {
        // GET: ProductType
        public ActionResult ProductTypeIndex()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddNewProductType([Bind(Include = "TypeName, IdCategory")] ProductType ObjType)
        {
            if (!string.IsNullOrEmpty(ObjType.TypeName) && ObjType.IdCategory != null)
            {
                var LastType = ProductTypeData.ProductTypeList.LastOrDefault();
                if (LastType == null)
                {
                    ObjType.Id = 1;
                    ProductTypeData.ProductTypeList.Add(ObjType);
                    return Json(ObjType, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ObjType.Id = +1;
                    ProductTypeData.ProductTypeList.Add(ObjType);
                    return Json(ObjType, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }//Close AddNewProductType

        [HttpGet]
        public JsonResult GetAllTypes()
        {
            return Json(ProductTypeData.ProductTypeList, JsonRequestBehavior.AllowGet);
        }//Close GetAllProducts
    }
}
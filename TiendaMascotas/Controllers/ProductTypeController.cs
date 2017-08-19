using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    public class ProductTypeController : Controller
    {
        // GET: ProductType
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getAllProductType()
        {
            try
            {
                if (Data.Data.ProductTypeList.Count > 0)
                {
                    return Json(Data.Data.ProductTypeList, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult AddProductType([Bind(Include = "Name,CategoryId")] ProductType pProductType)
        {
            try
            {
                if (!string.IsNullOrEmpty(pProductType.Name) && pProductType.CategoryId >= 0)
                {
                    var lastProductType = Data.Data.ProductTypeList.LastOrDefault();

                    if (lastProductType == null)
                    {
                        pProductType.Id = 1;
                        Data.Data.ProductTypeList.Add(pProductType);
                        return Json(pProductType, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        pProductType.Id = lastProductType.Id + 1;
                        Data.Data.ProductTypeList.Add(pProductType);
                        return Json(pProductType, JsonRequestBehavior.AllowGet);
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
        public JsonResult RemoveProductType(int? productTypeId)
        {
            try
            {
                if (productTypeId != null)
                {
                    var productType = Data.Data.ProductTypeList.Where(p => p.Id == productTypeId).FirstOrDefault();
                    if (productType != null)
                    {
                        Data.Data.ProductTypeList.Remove(productType);
                        return Json(true, JsonRequestBehavior.AllowGet);
                    }

                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetProductTypeById(int? productTypeId)
        {
            try
            {
                if (productTypeId != null)
                {
                    var productType = Data.Data.ProductTypeList.Where(p => p.Id == productTypeId).FirstOrDefault();
                    if (productType != null)
                    {
                        return Json(productType, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPut]
        public JsonResult UpdateProductType([Bind(Include = "Id,Name,CategoryId")] ProductType pProductType)
        {
            try
            {
                var foundProductType = Data.Data.ProductTypeList.Where(p => p.Id == pProductType.Id).FirstOrDefault();
                if (foundProductType != null)
                {
                    foundProductType.Name = pProductType.Name;
                    foundProductType.CategoryId = pProductType.CategoryId;
                    return Json(foundProductType, JsonRequestBehavior.AllowGet);
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
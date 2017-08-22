using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddProduct([Bind(Include = "ANCode,Name,Cost,ProductType")] Product pProduct)
        {
            try
            {
                if (!string.IsNullOrEmpty(pProduct.Code) && !string.IsNullOrEmpty(pProduct.Name) && pProduct.Price >= 0 && pProduct.IdProductType >= 0)
                {
                    pProduct.isSold = false;
                    var lastProduct = Data.Data.Products.LastOrDefault();

                    if (lastProduct == null)
                    {
                        pProduct.Id = 1;
                        Data.Data.Products.Add(pProduct);
                        return Json(pProduct, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        pProduct.Id = lastProduct.Id + 1;
                        Data.Data.Products.Add(pProduct);
                        return Json(pProduct, JsonRequestBehavior.AllowGet);
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
        public JsonResult RemoveProduct(int? productId)
        {
            try
            {
                if (productId != null)
                {
                    var product = Data.Data.Products.Where(p => p.Id == productId).FirstOrDefault();
                    if (product != null)
                    {
                        Data.Data.Products.Remove(product);
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
        public JsonResult getProduct(int? productId)
        {
            try
            {
                if (productId != null)
                {
                    var product = Data.Data.Products.Where(p => p.Id == productId).FirstOrDefault();
                    if (product != null)
                    {
                        return Json(product, JsonRequestBehavior.AllowGet);
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
        public JsonResult UpdateProduct([Bind(Include = "ANCode,Name,Cost,ProductType")] Product pProduct)
        {
            try
            {
                var foundProduct = Data.Data.Products.Where(p => p.Id == pProduct.Id).FirstOrDefault();
                if (foundProduct != null)
                {
                    foundProduct.Code = pProduct.Code;
                    foundProduct.Name = pProduct.Name;
                    foundProduct.Price = pProduct.Price;
                    foundProduct.IdProductType = pProduct.IdProductType;
                    return Json(foundProduct, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SoldProduct(int? productId)
        {
            try
            {
                if (productId != null)
                {
                    var foundProduct = Data.Data.Products.Where(p => p.Id == productId).FirstOrDefault();
                    if (foundProduct != null)
                    {
                        foundProduct.isSold = true;
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

    }
}
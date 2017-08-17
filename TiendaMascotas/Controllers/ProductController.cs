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

        public ActionResult Create()
        {
            return View();
        }

        public JsonResult getAllProducts()
        {
            try
            {
                return Json(Data.Data.ProductList, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddProduct([Bind(Include = "Code,Name,Price,IdProductType")] Product Product)
        {
            try
            {
                if (!string.IsNullOrEmpty(Product.Code) && !string.IsNullOrEmpty(Product.Name) && Product.Price >= 0 && Product.IdProductType >= 0)
                {
                    Product.isSold = false;
                    var lastProduct = Data.Data.ProductList.LastOrDefault();

                    if (lastProduct == null)
                    {
                        Product.Id = 1;
                        Data.Data.ProductList.Add(Product);
                        return Json(Product, JsonRequestBehavior.AllowGet);
                    }
                    Product.Id = lastProduct.Id + 1;
                    Data.Data.ProductList.Add(Product);
                    return Json(Product, JsonRequestBehavior.AllowGet);
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
                    var product = Data.Data.ProductList.Where(p => p.Id == productId).FirstOrDefault();
                    if (product != null)
                    {
                        Data.Data.ProductList.Remove(product);
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
                    var product = Data.Data.ProductList.Where(p => p.Id == productId).FirstOrDefault();
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
        public JsonResult UpdateProduct([Bind(Include = "Code,Name,Price,IdProductType")] Product Product)
        {
            try
            {
                var foundProduct = Data.Data.ProductList.Where(p => p.Id == Product.Id).FirstOrDefault();
                if (foundProduct != null)
                {
                    foundProduct.Code = Product.Code;
                    foundProduct.Name = Product.Name;
                    foundProduct.Price = Product.Price;
                    foundProduct.IdProductType = Product.IdProductType;
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
                    var foundProduct = Data.Data.ProductList.Where(p => p.Id == productId).FirstOrDefault();
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
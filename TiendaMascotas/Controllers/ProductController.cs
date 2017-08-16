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

        public JsonResult getAllProducts()
        {
            try
            {
                if(Data.Data.Products.Count > 0) {
                    return Json(Data.Data.Products, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddProduct([Bind(Include = "ANCode,Name,Cost,ProductType")] Product pProduct)
        {
            try
            {
                if (!string.IsNullOrEmpty(pProduct.ANCode) && !string.IsNullOrEmpty(pProduct.Name) && pProduct.Cost >= 0 && pProduct.ProductType>=0)
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
                    foundProduct.ANCode = pProduct.ANCode;
                    foundProduct.Name = pProduct.Name;
                    foundProduct.Cost = pProduct.Cost;
                    foundProduct.ProductType = pProduct.ProductType;
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



        //// GET: Product/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Product/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Product/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Product/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Product/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Product/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Product/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

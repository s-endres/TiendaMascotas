using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.Data;
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
        public JsonResult AddNewProduct([Bind(Include = "Code, Name, Category, Quantity, Price")] Product ObjProduct)
        {
            if (!string.IsNullOrEmpty(ObjProduct.Code) && !string.IsNullOrEmpty(ObjProduct.Name) && !string.IsNullOrEmpty(ObjProduct.Category) && !string.IsNullOrEmpty(ObjProduct.Quantity) && !string.IsNullOrEmpty(ObjProduct.Price))
            {
                var LastProduct = ProductData.ProductsList.LastOrDefault();
                if (LastProduct == null)
                {
                    ObjProduct.Id = 1;
                    ObjProduct.SoldStatus = false;
                    ProductData.ProductsList.Add(ObjProduct);
                    return Json(ObjProduct, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ObjProduct.Id = +1;
                    ObjProduct.SoldStatus = false;
                    ProductData.ProductsList.Add(ObjProduct);
                    return Json(ObjProduct, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }//Close AddNewProduct

        [HttpGet]
        public JsonResult DeleteProduct(int? pProductId)
        {
            if (pProductId != null)
            {
                var Product = ProductData.ProductsList.Where(P => P.Id == pProductId).FirstOrDefault();
                ProductData.ProductsList.Remove(Product);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }//Close DeleteProduct

        //Need to fix the SoldStatus
        [HttpPut]
        public JsonResult UpdateProduct([Bind(Include = "Id, Code, Name, Category, Quantity, Price")] Product ObjProduct)
        {
            if(ObjProduct.Id != null)
            {
                var EditProduct = ProductData.ProductsList.Where(P => P.Id == ObjProduct.Id).FirstOrDefault();
                EditProduct.Code = ObjProduct.Code;
                EditProduct.Name = ObjProduct.Name;
                EditProduct.Category = ObjProduct.Category;
                EditProduct.Quantity = ObjProduct.Quantity;
                EditProduct.Price = ObjProduct.Price;
                return Json(EditProduct, JsonRequestBehavior.AllowGet);
                //Sold Status ???
            }
            return Json(false, JsonRequestBehavior)
        }//Close UpdateProduct
    }
}
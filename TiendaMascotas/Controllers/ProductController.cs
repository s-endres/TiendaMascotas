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
        public ActionResult ProductIndex()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddNewProduct([Bind(Include = "Code, Name, Quantity, Price")] Product ObjProduct)
        {
            if (!string.IsNullOrEmpty(ObjProduct.Code) && !string.IsNullOrEmpty(ObjProduct.Name))
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
                    ObjProduct.Id = LastProduct.Id+1 ;
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
        public JsonResult UpdateProduct([Bind(Include = "Id, Code, Name, Price")] Product ObjProduct)
        {
            if(ObjProduct.Id != null)
            {
                var EditProduct = ProductData.ProductsList.Where(P => P.Id == ObjProduct.Id).FirstOrDefault();
                EditProduct.Code = ObjProduct.Code;
                EditProduct.Name = ObjProduct.Name;
                EditProduct.Price = ObjProduct.Price;
                return Json(EditProduct, JsonRequestBehavior.AllowGet);
                //Sold Status ???
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }//Close UpdateProduct

        [HttpGet]
        public JsonResult GetAllProducts()
        {
            return Json(ProductData.ProductsList, JsonRequestBehavior.AllowGet);
        }//Close GetAllProducts
    }
}
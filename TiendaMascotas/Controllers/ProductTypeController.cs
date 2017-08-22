﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    public class ProductTypeController : Controller
    {

        public struct ProductTypeStruct
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Count { get; set; }
        }

        // GET: ProductType
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult countProductsByType()
        {
            try
            {
                var ProductTypes = new List<ProductTypeStruct>();
                foreach (var ProductType in Data.Data.ProductTypes)
                {
                    ProductTypes.Add(new ProductTypeStruct()
                    {
                        Id = ProductType.Id,
                        Name = ProductType.Name,
                        Count = Data.Data.Products.Count(x => x.IdProductType == ProductType.Id)
                    });
                }
                return Json(ProductTypes, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult getAllProductType()
        {
            try
            {
                if (Data.Data.ProductTypes.Count > 0)
                {
                    return Json(Data.Data.ProductTypes, JsonRequestBehavior.AllowGet);
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
                if (!string.IsNullOrEmpty(pProductType.Name) && pProductType.IdCategory >= 0)
                {
                    var lastProductType = Data.Data.ProductTypes.LastOrDefault();

                    if (lastProductType == null)
                    {
                        pProductType.Id = 1;
                        Data.Data.ProductTypes.Add(lastProductType);
                        return Json(pProductType, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        pProductType.Id = lastProductType.Id + 1;
                        Data.Data.ProductTypes.Add(lastProductType);
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
                    var productType = Data.Data.ProductTypes.Where(p => p.Id == productTypeId).FirstOrDefault();
                    if (productType != null)
                    {
                        Data.Data.ProductTypes.Remove(productType);
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
        public JsonResult getProductType(int? productTypeId)
        {
            try
            {
                if (productTypeId != null)
                {
                    var productType = Data.Data.ProductTypes.Where(p => p.Id == productTypeId).FirstOrDefault();
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
        public JsonResult UpdateProductType([Bind(Include = "Name,CategoryId")] ProductType pProductType)
        {
            try
            {
                var foundProductType = Data.Data.ProductTypes.Where(p => p.Id == pProductType.Id).FirstOrDefault();
                if (foundProductType != null)
                {
                    foundProductType.Name = pProductType.Name;
                    foundProductType.IdCategory = pProductType.IdCategory;
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
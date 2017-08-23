using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        public struct ProductData
        {
            public string Nombre { get; set; }
            public double Price { get; set; }

        }

        [HttpPost]
        public JsonResult DoMyPurchase(List<int> ProductsId, [Bind(Include = "BaseTotal,NetTotal,Code,IdUser,Date,DiscountId")] Bill pBill)
        {
            try
            {
                if (!string.IsNullOrEmpty(pBill.Code) && !string.IsNullOrEmpty(pBill.Date.ToShortDateString()) && pBill.BaseTotal >= 0 && pBill.NetTotal >= 0 && pBill.IdUser >= 0)
                {
                    var lastBill = Data.Data.BillList.LastOrDefault();

                    if (lastBill == null)
                    {
                        pBill.Id = 1;
                        Data.Data.BillList.Add(pBill);                     
                    }
                    else
                    {
                        pBill.Id = lastBill.Id + 1;
                        Data.Data.BillList.Add(pBill);
                    }

                    var productData = new List<ProductData>();

                    foreach (var Product in ProductsId)
                    {
                        var lastPurchase = Data.Data.PurchaseList.LastOrDefault();
                        var newPurchase = new Purchase();
                        if (lastPurchase == null)
                        {
                            newPurchase.Id = 1;
                        }
                        else
                        {
                            newPurchase.Id = lastPurchase.Id + 1;
                        }
                        newPurchase.IdBill = pBill.Id;
                        newPurchase.IdProduct = Product;
                        Data.Data.PurchaseList.Add(newPurchase);
                        var product = Data.Data.ProductList.Where(x => x.Id == Product).SingleOrDefault();
                        product.isSold = true;
                        productData.Add(new ProductData { Nombre = product.Name, Price = product.Price });
                    }
                    return Json(true, JsonRequestBehavior.AllowGet);
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

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

        public struct ProductData{
            public string Nombre { get; set; }
            public double Cost { get; set; }

        }

        [HttpPost]
        public JsonResult DoMyPurchase(List<int> ProductsId, [Bind(Include = "BaseTotal,NetTotal,Code,UserId,UserId,Date,DiscountId")] Bill pBill)
        {
            try
            {
                if (!string.IsNullOrEmpty(pBill.Code) && !string.IsNullOrEmpty(pBill.Date.ToShortDateString()) && pBill.BaseTotal >= 0 && pBill.NetTotal >= 0 && pBill.UserId >= 0)
                {
                    var lastBill = Data.Data.Bills.LastOrDefault();

                    if (lastBill == null){
                        pBill.Id = 1;
                        Data.Data.Bills.Add(pBill);
                        //return Json(pBill, JsonRequestBehavior.AllowGet);
                    }
                    else {
                        pBill.Id = lastBill.Id + 1;
                        Data.Data.Bills.Add(pBill);
                    }
                    
                    var productData = new List<ProductData>();
                    foreach (var Product in ProductsId) {
                        Data.Data.Purchases.Add(new Purchase
                        {
                            //AGREGAR ID POR FAVOR -Ricardo
                            BillId = pBill.Id,
                            Product = Product
                        });
                        var product = Data.Data.Products.Where(x => x.Id == Product).SingleOrDefault();
                        product.isSold = true;
                        productData.Add(new ProductData { Nombre = product.Name, Cost = product.Cost });
                    }
                    return Json(pBill, JsonRequestBehavior.AllowGet);
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
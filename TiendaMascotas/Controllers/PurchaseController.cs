using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.Models;
using TiendaMascotas.Data;

namespace TiendaMascotas.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        public struct PurchaseData
        {
            public Bill Bill { get; set; }
            public List<Product> Products { get; set; }
        }

        public JsonResult AddPurchase([Bind(Include = "Code, IdUser")] Bill Bill, List<int> ProductIds)
        {
            //FALTA EL ADD DISCOUNT
            var LastBill = Data.Data.Bills.LastOrDefault();
            if(LastBill == null)
            {
                Bill.Id = 1;
            }
            else
            {
                Bill.Id = LastBill.Id + 1;
            }
            Bill.Date = DateTime.Now;
            Data.Data.Bills.Add(Bill);
            List<Product> ProductList = new List<Product>();
            foreach(var Product in ProductIds)
            {
                var Last = Data.Data.Purchases.LastOrDefault();
                if (Last == null) {
                    Data.Data.Purchases.Add(new Purchase()
                    {
                        Id = 1,
                        IdBill = Bill.Id,
                        IdProduct = Product
                    });
                }
                else
                {
                    Data.Data.Purchases.Add(new Purchase()
                    {
                        Id = Last.Id + 1,
                        IdBill = Bill.Id,
                        IdProduct = Product
                    });
                }
                ProductList.Add(Data.Data.Products.Where(x => x.Id == Product).FirstOrDefault());
            }
            return Json(new PurchaseData {
                Bill = Bill,
                Products = ProductList
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
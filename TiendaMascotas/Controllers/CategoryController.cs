using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult getAllCategories()
        {
            try
            {
                var CategoryList = Data.Data.CategoryList.Where(f => f.isDelete == false).ToList();
                return Json(CategoryList, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult getCategory(int? CategoryId)
        {
            try
            {
                if (CategoryId != null)
                {
                    var Category = Data.Data.CategoryList.Where(c => c.Id == CategoryId).FirstOrDefault();
                    if (Category != null)
                    {
                        return Json(Category, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddCategory([Bind(Include = "Name")] Category pCategory)
        {
            try
            {
                if (!string.IsNullOrEmpty(pCategory.Name))
                {
                    var LastCategory = Data.Data.CategoryList.LastOrDefault();

                    if (LastCategory == null)
                    {
                        pCategory.Id = 1;
                        Data.Data.CategoryList.Add(pCategory);
                        return Json(pCategory, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        pCategory.Id = LastCategory.Id + 1;
                        Data.Data.CategoryList.Add(pCategory);
                        return Json(pCategory, JsonRequestBehavior.AllowGet);
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
        public JsonResult RemoveCategory(int? CategoryId)
        {
            try
            {
                if (CategoryId != null)
                {              
                    var productTypeList = Data.Data.ProductTypeList.Where(f => f.CategoryId == CategoryId).ToList();
                    var Category = Data.Data.CategoryList.Where(c => c.Id == CategoryId).FirstOrDefault();
                    if (Category != null)
                    {
                        Category.isDelete = true;
                        foreach (var ProducType in productTypeList)
                        {
                            ProducType.isDelete = true;
                            var productList = Data.Data.ProductList.Where(f => f.IdProductType == ProducType.Id).ToList();
                            foreach (var Product in productList)
                            {
                                Product.IdProductType = 0;
                            }
                        }
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

        [HttpPut]
        public JsonResult UpdateCategory([Bind(Include = "Id,Name")] Category pCategory)
        {
            try
            {
                var foundCategory = Data.Data.CategoryList.Where(c => c.Id == pCategory.Id).FirstOrDefault();
                if (foundCategory != null)
                {
                    foundCategory.Name = pCategory.Name;
                    return Json(foundCategory, JsonRequestBehavior.AllowGet);
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
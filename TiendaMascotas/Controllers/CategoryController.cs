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
                if (Data.Data.Categories.Count > 0)
                {
                    return Json(Data.Data.Categories, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
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
                    var Category = Data.Data.Categories.Where(c => c.Id == CategoryId).FirstOrDefault();
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
                    var LastCategory = Data.Data.Categories.LastOrDefault();

                    if (LastCategory == null)
                    {
                        pCategory.Id = 1;
                        Data.Data.Categories.Add(pCategory);
                        return Json(pCategory, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        pCategory.Id = LastCategory.Id + 1;
                        Data.Data.Categories.Add(pCategory);
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
        public JsonResult RemoveCategory(int? pCategoryId)
        {
            try
            {
                if (pCategoryId != null)
                {
                    var Category = Data.Data.Categories.Where(c => c.Id == pCategoryId).FirstOrDefault();
                    if (Category != null)
                    {
                        Data.Data.Categories.Remove(Category);
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
        public JsonResult UpdateCategory([Bind(Include = "Name")] Category pCategory)
        {
            try
            {
                var foundCategory = Data.Data.Categories.Where(c => c.Id == pCategory.Id).FirstOrDefault();
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
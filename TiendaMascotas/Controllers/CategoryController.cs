using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMascotas.Data;
using TiendaMascotas.Models;

namespace TiendaMascotas.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult CategoryIndex()
        {
            return View();
        }

        public JsonResult GetAllCategories()
        {
            return Json(CategoryData.CategoryList, JsonRequestBehavior.AllowGet);
        }//Close GetAllCategories

        public JsonResult AddNewCategory([Bind(Include = "Name")] Category ObjCategory)
        {
            if (!string.IsNullOrEmpty(ObjCategory.Name))
            {
                var LastCategory = CategoryData.CategoryList.LastOrDefault();
                if (LastCategory == null)
                {
                    ObjCategory.Id = 1;
                    CategoryData.CategoryList.Add(ObjCategory);
                    return Json(ObjCategory, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ObjCategory.Id = LastCategory.Id + 1;
                    CategoryData.CategoryList.Add(ObjCategory);
                    return Json(ObjCategory, JsonRequestBehavior.AllowGet);
                }                
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }//
    }
}
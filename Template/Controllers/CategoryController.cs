using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Template.Models;

namespace Template.Controllers
{

    public class CategoryController : Controller
    {
        frrEntities db = new frrEntities();
        public ActionResult Index()
        {
            var query = db.tblCategory.ToList();
            return View(query);
        }


        // GET: Catagory
        public ActionResult Create()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult Create(tblCategory c)
        {
            if (ModelState.IsValid)
            {
                tblCategory cat = new tblCategory();
                cat.Name = c.Name;
                db.tblCategory.Add(cat);
                db.SaveChanges();
                return RedirectToAction("Create", "Product");



            }
            else
            {
                TempData["msg"] = "not inserted Category";
            }


            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;

using System.IO;

namespace SDLab.Controllers
{
    public class ProductController : Controller
    {
        frrEntities db = new frrEntities();
        // GET: Product
        public ActionResult Index()
        {
            var query = db.tblProduct.ToList();
            return View(query);
        }
        public ActionResult Create()
        {
            List<tblCategory> list = db.tblCategory.ToList();
            ViewBag.catList = new SelectList(list, "CatId", "Name");

            return View();
        }
        [HttpPost]
        public ActionResult Create(tblProduct p, HttpPostedFileBase Image)
        {
            List<tblCategory> list = db.tblCategory.ToList();
            ViewBag.catList = new SelectList(list, "CatId", "Name");
            if (ModelState.IsValid)
            {
                tblProduct pro = new tblProduct();
                pro.Name = p.Name;
                pro.Description = p.Description;
                pro.Unit = p.Unit;

                pro.Image = Image.FileName.ToString();
                //image
                var folder = Server.MapPath("../Uploads/");
                Image.SaveAs(Path.Combine(folder, Image.FileName.ToString()));
                pro.CatId = p.CatId;
                db.tblProduct.Add(pro);
                db.SaveChanges();

                return RedirectToAction("Index");



            }
            else
            {
                TempData["msg"] = "Product not uploaded";
                return Content("failed");
            }
        }
      

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;

namespace Template.Controllers
{
    public class AdminController : Controller

    {
        frrEntities db = new frrEntities();
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Messages()
        {
            var query = db.tblContact.ToList();

            return View(query);
        }
        public ActionResult Orders()
        {
            var query = db.tblOrder.ToList();

            return View(query);
        }
       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Template.Models;

namespace Template.Controllers
{
    public class AccountController : Controller
    {// naam change korbo pore database er
        frrEntities db = new frrEntities();

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tblUser t)
        {
            tblUser u = new tblUser();
            if (ModelState.IsValid)
            {
                u.Name = t.Name;
                u.Email = t.Email;
                u.Password = t.Password;
                u.RoleType = 2;
                db.tblUser.Add(u);
                db.SaveChanges();
                return RedirectToAction("Login", "Account");

            }
            else
            {
                TempData["msg"] = "Not Register";
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblUser t)
        {
            var query = db.tblUser.SingleOrDefault(m => m.Email == t.Email && m.Password == t.Password);
            if (query != null)
            {
                if (query.RoleType == 1)
                {
                    FormsAuthentication.SetAuthCookie(query.Email, false);
                    Session["uid"] = query.UserId;
                    Session["User"] = query.Email;
                    return RedirectToAction("Dashboard", "Admin");
                }
                else if (query.RoleType == 2)
                {
                    FormsAuthentication.SetAuthCookie(query.Email, false);
                    Session["User"] = query.Email;
                    Session["uid"] = query.UserId;




                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["msg"] = "Invalid username or password";
            }

            return View();
        }
       
    }
}
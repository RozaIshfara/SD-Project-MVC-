using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Template.Models;
namespace Template.Controllers
{
    public class HomeController : Controller
    {
        frrEntities db = new frrEntities();
        List<Cart> li = new List<Cart>();
        public ActionResult Index()
        {
            if (Session["cart"] != null)
            {
                int x = 0;

                List<Cart> li2 =Session["cart"] as List<Cart>;
                foreach (var item in li2)
                {
                    x += item.bill;

                }
                Session["total"] = x;
                Session["item_count"] = li2.Count();
            }
            

            var query = db.tblProduct.ToList();
            return View(query);
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Gallery()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        [HttpPost]
        public ActionResult Contact(tblContact t)
        {
            tblContact u = new tblContact();
            if (ModelState.IsValid)
            {
                u.Name = t.Name;
                u.Message = t.Message;
                u.UserId = Convert.ToInt32(Session["uid"].ToString());
                db.tblContact.Add(u);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                TempData["msg"] = "Message not sent";
            }
            return View();
        }
        public ActionResult Services()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            Session["User"] = null;
            return RedirectToAction("Index", "Home");

        }
        public ActionResult Menu()
        {
        
            var query = db.tblProduct.ToList();
            return View(query);
        }
        public ActionResult AddtoCart(int id)
        {
            var query = db.tblProduct.Where(x => x.ProID == id).SingleOrDefault();
            return View(query);
        }
        [HttpPost]
        public ActionResult AddtoCart(int id, int qty)
        {
            tblProduct p = db.tblProduct.Where(x => x.ProID == id).SingleOrDefault();
            Cart c = new Cart();
            c.proid = id;
            c.proname = p.Name;
            c.price = Convert.ToInt32(p.Unit);
            c.qty = Convert.ToInt32(qty);
            c.bill = c.price * c.qty;
            if (Session["cart"] == null)
            {
                li.Add(c);
                Session["cart"] = li;




               
            }
            else
            {
                List<Cart> li2 = Session["cart"] as List<Cart>;
                int flag = 0;
                foreach (var item in li2)
                {
                    if (item.proid == c.proid)
                    {
                        item.qty += c.qty;
                        item.bill += c.bill;
                        flag = 1;
                    }

                }
                if (flag == 0)
                {
                    li2.Add(c);
                    //new item
                }
               Session["cart"] = li2;

            }
           

          

            return RedirectToAction("Index");
        }

        public ActionResult Checkout()
        {
          
            return View();
        }






        [HttpPost]
        public ActionResult Checkout(string contact, string address)
        {
            if (ModelState.IsValid)
            {
                List<Cart> li2 = Session["cart"] as List<Cart>;
                tblInvoice iv = new tblInvoice();
                iv.UserId = Convert.ToInt32(Session["uid"].ToString());
                iv.InvoiceDate = System.DateTime.Now;
                iv.Bill = (int)Session["total"];
                iv.Payment = "cash";
                db.tblInvoice.Add(iv);
                db.SaveChanges();
                //order book
                foreach (var item in li2)
                {
                    tblOrder od = new tblOrder();
                    od.ProID = item.proid;
                    od.Contact = contact;
                    od.Address = address;
                    od.OrderDate = System.DateTime.Now;
                   
                    od.Qty = item.qty;
                    od.Unit = item.price;
                    od.Total = item.bill;

                    db.tblOrder.Add(od);
                    db.SaveChanges();

                }
                Session.Remove("total");
                Session.Remove("cart");
                // Session["msg"] = "Order Book Successfully!!";
                @Session["item_count"] = null;
                return RedirectToAction("Index");

            }

          
            return View();
        }


        public ActionResult remove(int? id)
        {
            if (Session["cart"] == null)
            {
                Session.Remove("total");
                Session.Remove("cart");
            }
            else
            {
                List<Cart> li2 = Session["cart"] as List<Cart>;
                Cart c = li2.Where(x => x.proid == id).SingleOrDefault();
                li2.Remove(c);
                int s = 0;
                foreach (var item in li2)
                {
                    s += item.bill;
                }
                Session["total"] = s;

            }

            return RedirectToAction("Index");
        }
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
  
}
using PharmacyManagementSystem.Models;
using PharmaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PharmacyManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private PMSDBContext db = new PMSDBContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogInAsAdmin()
        {
            return View("LogInAsAdmin");
        }
        [HttpPost]
        public ActionResult LogInAsAdmin(string username, string password)
        {
            if (username == "Admin" && password == "admin123@")
            {
                return RedirectToAction("Index", "PMSCats");
            }
            else
            {
                ViewBag.Notification = "Wrong Username or Password";
                return View();
            }
        }

        public ActionResult LogInAsSeller()
        {
            return View("LogInAsSeller");
        }

        [HttpPost]
        public ActionResult LogInAsSeller([Bind(Include = "SelId,SelEmail,SelPwd")] PMSSeller pMSSeller)
        {
            if (Cls_Admin.Authenticate(pMSSeller.SelEmail, pMSSeller.SelPwd) > 0)
            {
                Session["seller"] = pMSSeller.SelId;
                return RedirectToAction("Index", "PMSBills");
            }
            else
            {
                ViewBag.Notification = "Wrong Username or Password";
                return View();
            }
        }

        public ActionResult AboutUs()
        {
            return View("AboutUs");
        }
        
    }
}
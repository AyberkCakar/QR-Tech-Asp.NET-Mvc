using QRTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRTech.Controllers
{
    public class AdminController : Controller
    {
        Admin admin;
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DiscountEdit(Price Entity)
        {
            AdminDatabase.LineDiscount(Entity);
            return View();
        }

        [HttpGet]
        public ActionResult DiscountEdit()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin Entity)
        {
            int islem = 0;
            if (Entity.kullanıcıAdi == null || Entity.Sifre == null)
            {
                islem = -1;
                ViewBag.islem = islem;
                return View("Login", admin);
            }
            else if (AdminDatabase.AdminControl(Entity) == true)
            {
                admin = AdminDatabase.GetAdmin;
                islem = 1;
                ViewBag.islem = islem;
                return View("Index", admin);
            }
            else
            {
                islem = -1;
                ViewBag.islem = islem;
                return View("Login", admin);
            }
        }

    }
}
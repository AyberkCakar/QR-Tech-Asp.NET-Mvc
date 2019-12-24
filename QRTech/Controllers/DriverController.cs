using QRTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRTech.Controllers
{
    public class DriverController : Controller
    {
        // GET: Driver
        public ActionResult Index()
        {
            List<Driver> drivers = new List<Driver>();
            drivers = AdminDatabase.DriverListe;
            return View(drivers);
        }

        [HttpPost]
        public ActionResult DriverCreate([Bind(Prefix = "Item1")]Driver Model1, [Bind(Prefix = "Item2")]Vehicle Model2)
        {
            AdminDatabase.DriverAdd(Model1,Model2);
            return View();
        }

        public ActionResult DriverCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DriverEdit(Driver Entity)
        {
            int islem = 0;
            try
            {
                AdminDatabase.DriverUpdate(Entity);
                ViewBag.islem = 1;
                Driver driver = new Driver();
                return View(driver);
            }
            catch (Exception)
            {
                ViewBag.islem = -1;
                return View(Entity);
            }
        }

        public ActionResult DriverEdit(int id)
        {

            Driver driver = new Driver();
            driver = AdminDatabase.DriverFind(id);
            return View(driver);
        }

        [HttpPost]
        public ActionResult DriverDelete(Driver Entity)
        {
            int islem = 0;
            try
            {
                AdminDatabase.DriverDelete(Entity);
                ViewBag.islem = 1;
                Driver driver = new Driver();
                return View(driver);
            }
            catch (Exception)
            {
                ViewBag.islem = -1;
                return View(Entity);
            }
        }

        public ActionResult DriverDelete(int id)
        {
            Driver driver = new Driver();
            driver = AdminDatabase.DriverFind(id);
            return View(driver);
        }
    }
}
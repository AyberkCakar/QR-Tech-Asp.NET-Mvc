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
        public ActionResult DriverCreate(Driver Entity)
        {
            int islem = 0;
            bool durum = TFuncAdmin.SoforEkleKontrol(Entity.AD, Entity.Soyad, Entity.TC, Entity.ehliyetSeriNo, Entity.Maas, Entity.AracPlaka, Entity.Telefon, Entity.Mail, Entity.Adres);
            try
            {
                if (durum == true)
                {
                    AdminDatabase.DriverAdd(Entity);
                    ViewBag.islem = 1;
                }
                else
                    ViewBag.islem = -1;

            }
            catch (Exception)
            {
                ViewBag.islem = -1;
            }

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
            bool durum = TFuncAdmin.SoforGuncelleKontrol(Entity.AD, Entity.Soyad, Entity.TC, Entity.ehliyetSeriNo, Entity.Maas, Entity.AracPlaka, Entity.Telefon, Entity.Mail, Entity.Adres,Entity.soforID);
            try
            {
                if (durum == true)
                {
                    AdminDatabase.DriverUpdate(Entity);
                    ViewBag.islem = 1;
                }
                else
                    ViewBag.islem = -1;

                return View(Entity);
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
                return View(Entity);
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
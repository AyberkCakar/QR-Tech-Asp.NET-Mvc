using QRTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRTech.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index()
        {
            List<Vehicle> _vehicle = new List<Vehicle>();
            _vehicle = AdminDatabase.VehicleListe;
            return View(_vehicle);
        }
        
        [HttpPost]
        public ActionResult VehicleCreate(Vehicle Entity)
        {
            int islem = 0;
            bool durum = TFuncAdmin.AracEkleKontrol(Entity.Plaka, Entity.AracMarka, Entity.Model, Entity.Renk, Entity.saseNumarasi, Entity.HatNo);
            try
            {
                if (durum == true)
                {
                    AdminDatabase.VehicleAdd(Entity);
                    ViewBag.islem = 1;
                }
                else
                {
                    ViewBag.islem = -1;
                }
                return View(Entity);
            }
            catch (Exception)
            {
                ViewBag.islem = -1;
                return View(Entity);
            }
        }
        public ActionResult VehicleCreate()
        {

            return View();
        }

        [HttpPost]
        public ActionResult VehicleEdit(Vehicle Entity)
        {
            int islem = 0;
            bool durum = TFuncAdmin.AracGuncelleKontrol(Entity.Plaka, Entity.AracMarka, Entity.Model, Entity.Renk, Entity.saseNumarasi, Entity.HatNo, Entity.aracID);
            try
            {
                if (durum == true)
                {
                    AdminDatabase.VehicleUpdate(Entity);
                    ViewBag.islem = 1;
                }
                else
                {
                    ViewBag.islem = -1;
                }
                return View(Entity);
            }
            catch (Exception)
            {
                ViewBag.islem = -1;
                return View(Entity);
            }
        }

        public ActionResult VehicleEdit(int id)
        {
            
            Vehicle vehicle = new Vehicle();
            vehicle = AdminDatabase.VehicleFind(id, AdminDatabase.VehicleLineID(id));
            return View(vehicle);
        }

        [HttpPost]
        public ActionResult VehicleDelete(Vehicle Entity)
        {
            int islem = 0;
            try
            {
                AdminDatabase.VehicleDelete(Entity);
                ViewBag.islem = 1;
                Vehicle vehicle = new Vehicle();
                return View(vehicle);
            }
            catch (Exception)
            {
                ViewBag.islem = -1;
                return View(Entity);
            }
        }
        public ActionResult VehicleDelete(int id)
        {
            Vehicle vehicle = new Vehicle();
            vehicle = AdminDatabase.VehicleFind(id, AdminDatabase.VehicleLineID(id));
            return View(vehicle);
        }
    }
}
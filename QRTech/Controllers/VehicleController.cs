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
        public ActionResult VehicleCreate([Bind(Prefix = "Item1")]Line Model1, [Bind(Prefix = "Item2")]Vehicle Model2)
        {
            AdminDatabase.VehicleAdd(Model1,Model2);
            return View();
        }
        public ActionResult VehicleCreate()
        {
            return View(Tuple.Create<Line, Vehicle>(new Line(), new Vehicle()));
        }

        [HttpPost]
        public ActionResult VehicleEdit(Vehicle Entity)
        {
            int islem = 0;
            try
            {
                AdminDatabase.VehicleUpdate(Entity);
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

        public ActionResult VehicleEdit(int id)
        {
            Vehicle vehicle = new Vehicle();
            vehicle = AdminDatabase.VehicleFind(id);
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
            vehicle = AdminDatabase.VehicleFind(id);
            return View(vehicle);
        }
    }
}
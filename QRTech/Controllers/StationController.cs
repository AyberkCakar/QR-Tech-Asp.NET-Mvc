using QRTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRTech.Controllers
{
    public class StationController : Controller
    {
        // GET: Station
        public ActionResult Index()
        {
            List<Station> stations = new List<Station>();
            stations = AdminDatabase.StationListe;
            return View(stations);
        }

        [HttpPost]
        public ActionResult StationCreate(Station Entity)
        {
            AdminDatabase.StationAdd(Entity);
            return View();
        }
        
        public ActionResult StationCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StationEdit(Station Entity)
        {
            int islem = 0;
            try
            {
                AdminDatabase.StationUpdate(Entity);
                ViewBag.islem = 1;
                Station station = new Station();
                return View(station);
            }
            catch (Exception)
            {
                ViewBag.islem = -1;
                return View(Entity);
            }
        }

        public ActionResult StationEdit(int id)
        {
            Station station = new Station();
            station = AdminDatabase.StationFind(id);
            return View(station);
        }

        [HttpPost]
        public ActionResult StationDelete(Station Entity)
        {
            int islem = 0;
            try
            {
                AdminDatabase.StationDelete(Entity);
                ViewBag.islem = 1;
                Station station = new Station();
                return View(station);
            }
            catch (Exception)
            {
                ViewBag.islem = -1;
                return View(Entity);
            }
        }

        public ActionResult StationDelete(int id)
        {
            Station station = new Station();
            station = AdminDatabase.StationFind(id);
            return View(station);
        }
    }
}
using QRTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRTech.Controllers
{
    public class LineController : Controller
    {
        // GET: Line
        public ActionResult Index()
        {
            List<Line> lines = new List<Line>();
            lines = AdminDatabase.LineListe;

            return View(lines);
        }

        [HttpPost]
        public ActionResult LineCreate([Bind(Prefix = "Item1")] Line Model1, [Bind(Prefix = "Item2")]Price Model2)
        {
            AdminDatabase.LineAdd(Model1,Model2);
            return View();
        }

        public ActionResult LineCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LineEdit(Line Entity)
        {
            int islem = 0;
            try
            {
                AdminDatabase.LineUpdate(Entity);
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

        public ActionResult LineEdit(int id)
        {
            Line line = new Line();
            line = AdminDatabase.LineFind(id);
            return View(line);
        }

        [HttpPost]
        public ActionResult LineDelete(Line Entity)
        {
            int islem = 0;
            try
            {
                AdminDatabase.LineDelete(Entity);
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

        public ActionResult LineDelete(int id)
        {
            Line line = new Line();
            line = AdminDatabase.LineFind(id);
            return View(line);
        }
    }
}
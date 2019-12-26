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
        public ActionResult LineCreate(Line Entity)
        {
            int islem = 0;
            bool durum = TFuncAdmin.HatEkleKontrol(Entity.HatNo, Entity.BaslangicDurak, Entity.BitisDurak, Entity.tamFiyat, Entity.ogrenciFiyat);
            try
            {
                if (durum == true)
                {
                    AdminDatabase.LineAdd(Entity);
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

        public ActionResult LineCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LineEdit(Line Entity)
        {
            int islem = 0;
            bool durum = TFuncAdmin.HatGuncelleKontrol(Entity.HatNo, Entity.BaslangicDurak, Entity.BitisDurak, Entity.tamFiyat, Entity.ogrenciFiyat, Entity.HatID);
            try
            {
                if (durum == true)
                {
                    AdminDatabase.LineUpdate(Entity);
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
            bool durum = TFuncAdmin.HatGuncelleKontrol(Entity.HatNo, Entity.BaslangicDurak, Entity.BitisDurak, Entity.tamFiyat, Entity.ogrenciFiyat,Entity.HatID);
            try
            {
                if (durum == true)
                {
                    AdminDatabase.LineDelete(Entity);
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

        public ActionResult LineDelete(int id)
        {
            Line line = new Line();
            line = AdminDatabase.LineFind(id);
            return View(line);
        }
    }
}
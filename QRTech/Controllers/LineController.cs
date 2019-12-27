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
        public ActionResult LineCreate(int HatNo, string BaslangicDurak, string BitisDurak, float ogrenciFiyat, float tamFiyat)
        {
            int islem = 0;
            Line Entity = new Line();
            bool durum = TFuncAdmin.HatEkleKontrol(HatNo, BaslangicDurak, BitisDurak, tamFiyat, ogrenciFiyat);
            try
            {
                if (durum == true)
                {
                    AdminDatabase.LineAdd(HatNo, BaslangicDurak, BitisDurak, ogrenciFiyat, tamFiyat);
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
        public ActionResult LineEdit(int HatID,int HatNo,string BaslangicDurak,string BitisDurak, int ogrenciFiyat,int tamFiyat)
        {
            int islem = 0;
            Line Entity = new Line();
            bool durum = TFuncAdmin.HatGuncelleKontrol(HatNo, BaslangicDurak, BitisDurak, tamFiyat, ogrenciFiyat, HatID);
            try
            {
                if (durum == true)
                {
                    AdminDatabase.LineUpdate (HatID,HatNo, BaslangicDurak, BitisDurak, ogrenciFiyat, tamFiyat);
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
            try
            {
                AdminDatabase.LineDelete(Entity);
                ViewBag.islem = 1;
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
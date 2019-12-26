using QRTech.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRTech.Controllers
{
    public class HomeController : Controller
    {
        static User user = new User();
        
        // GET: Home
        public ActionResult Index()
        {
            user = UserDataBase.GetUser;
            return View(user);
        }

        [HttpPost]
        public ActionResult BalanceUpdate(User entity)
        {
            int islem = 0;
            entity.TC = user.TC;
            entity.kullanıcıID = user.kullanıcıID;
            bool durum = TFunc.formOdemeBosKontrol(entity.TC, entity.Bakiye, entity.KKNo1, entity.KKNo2, entity.KKNo3, entity.KKNo4, entity.KKSahip, entity.KKSonTarihAy, entity.KKSonTarihYıl, entity.KKCVV);
            try
            {
                if (durum == true)
                {
                    UserDataBase.BalanceUpdate(entity);
                    islem = 1;
                }
                else
                    islem = -1;

            }
            catch (Exception)
            {
                islem = -1;
            }
            UserDataBase.UserControl(user);
            user = UserDataBase.GetUser;
            ViewBag.islem = islem;
            return View("BalanceUpdate",user);
        }

        public ActionResult BalanceUpdate()
        {
            UserDataBase.UserControl(user);
            user = UserDataBase.GetUser;
            return View(user);
        }

        [HttpPost]
        public ActionResult BalanceSend(User entity)
        {
            int islem = 0;
            entity.TC = user.TC;
            entity.kullanıcıID = user.kullanıcıID;
            try
            {
                if (UserDataBase.GetUser.Bakiye >= entity.Bakiye)
                {
                    UserDataBase.BalanceSend(entity);
                    islem = 1;
                }
                else
                    islem = -1;
            }
            catch (Exception)
            {
                islem = -1;
            }
            ViewBag.islem = islem;
            UserDataBase.UserControl(user);
            user = UserDataBase.GetUser;
            return View(user);
        }

        public ActionResult BalanceSend()
        {
            UserDataBase.UserControl(user);
            user = UserDataBase.GetUser;
            return View(user);
        }

        [HttpPost]
        public ActionResult InformationUpdate(User entity)
        {
            int islem = 0;
            entity.TC = user.TC;
            try
            {
                UserDataBase.InformationUpdate(entity);
                islem = 1;
            }
            catch (Exception)
            {
                islem = -1;
                throw;
            }
            ViewBag.islem = islem;
            UserDataBase.UserControl(user);
            user = UserDataBase.GetUser;
            ///
            return View(user);
        }

        public ActionResult InformationUpdate()
        {
            UserDataBase.UserControl(user);
            user = UserDataBase.GetUser;
            return View(user);
        }

        [HttpPost]
        public ActionResult InformationPasswordUpdate(User entity)
        {
            int islem = 0;
            entity.TC = user.TC;
            if (entity.Sifre == entity.SifreTekrar && user.Sifre == entity.EskiSifre)
            {
                UserDataBase.InformationPasswordUpdate(entity);
                islem = 1;

            }
            else
                islem = -1;
            ViewBag.islem = islem;
            UserDataBase.UserControl(entity);
            user = UserDataBase.GetUser;
            return View("InformationPasswordUpdate",user);
        } 
        public ActionResult InformationPasswordUpdate()
        {
            UserDataBase.UserControl(user);
            user = UserDataBase.GetUser;
            return View(user);
        }
        public ActionResult Ticket()
        {
            user.islem = 0;
            return View();
        }

        [HttpPost]
        public ActionResult Ticket(string qrCode , string scanner)
        {
            int islem = 0;
            try
            {
                int hatID;
                hatID=Convert.ToInt32(qrCode);
                UserDataBase.UserPayment(user, hatID);
                islem = 1;
                user = UserDataBase.GetUser;

            }
            catch (Exception)
            {
                islem = -1;
            }

            ViewBag.islem = islem;
            return View();
        }

        public ActionResult Login()
        {
            User user = new User();
            return View();
        }
        private bool sayiMi(string tc)
        {
            bool kontrol=false;
            try
            {
                kontrol = Convert.ToInt64(tc) / 1 == Convert.ToInt64(tc) || Convert.ToInt64(tc) / 2 == Convert.ToInt64(tc) / 2 ? true : false;
            }
            catch (Exception)
            {
                kontrol = false;
            }
            return kontrol;
        }

        [HttpPost]
        public ActionResult Login(User entity)
        {
            int islem = 0;
            if (entity.TC == null || entity.Sifre == null)
            {
                islem = -1;
                ViewBag.islem = islem;
                return View("Login", user);
            }
            else if (sayiMi(entity.TC)==true && UserDataBase.UserControl(entity) == true)
            {
                user=UserDataBase.GetUser;
                islem = 1;
                ViewBag.islem = islem;
                return View("Index", user);
            }
            
            else
            {
                islem = -1;
                ViewBag.islem = islem;
                return View("Login", user);
            }
            
        }

        public ActionResult Create()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User entity)
        {

            int islem = 0;
            try
            {
                bool durum = TFunc.formBosKontrol(entity.AD, entity.Soyad, entity.TC, entity.Mail, entity.Adres, entity.Telefon, entity.Sifre, entity.yolcuTip);
                if (durum == true && sayiMi(entity.TC)==true && entity.Sifre == entity.SifreTekrar)
                {
                    UserDataBase.UserCreate(entity);
                    ViewBag.islem = 1; 
                    return View("Login", user);
                }
                else
                {
                    ViewBag.islem = -1;
                    return View("Create", entity);
                }
            }
            catch (Exception)
            {
                ViewBag.islem = -1;
                return View("Create", entity);
            }           
        }
    }
}
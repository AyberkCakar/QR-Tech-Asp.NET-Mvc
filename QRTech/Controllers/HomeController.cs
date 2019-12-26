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
            try
            {

                UserDataBase.BalanceUpdate(entity);
                islem = 1;

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
            else if (UserDataBase.UserControl(entity) == true)
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

            user.islem = 0;
            try
            {
                UserDataBase.UserCreate(entity);
                return View("Login", user);
            }
            catch (Exception)
            {
                return View("Create", entity);

            }           
        }
    }
}
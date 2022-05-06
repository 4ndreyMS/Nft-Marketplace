using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NFTSaleManager()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Marketplace()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Collection()
        {
            return View();
        }

        public ActionResult Wallet()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult EditProfile()
        {
            return View();
        }

        public ActionResult SubmitRequest()
        {
            return View();
        }

        public ActionResult RegisterContentCreator()
        {
            return View();
        }

        public ActionResult ItemDetails()
        {
            return View();
        }

        public ActionResult Manager()
        {
            return View();
        }

        public ActionResult RegisterNFT()
        {
            return View();
        }

        public ActionResult CreateCollection()
        {
            return View();
        }

        public ActionResult BuyCFC()
        {
            return View();
        }

        public ActionResult ShoppingCart()
        {
            return View();

        }

        public ActionResult OffersTable()
        {
            return View();

        }


        public ActionResult Activity()
        {
            return View();
        }
    }
}
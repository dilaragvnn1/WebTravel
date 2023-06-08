using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Travel_Projesi.Models.Siniflar;

namespace Travel_Projesi.Controllers
{
    public class GirisYapController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin Ad)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == Ad.Kullanici && x.Sifre== Ad.Sifre);
            if (bilgiler != null) 
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"]=bilgiler.Kullanici.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "GirisYap");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using Travel_Projesi.Models.Siniflar;
namespace Travel_Projesi.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
           /// var bloglar = c.Blogs.ToList();
           by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.Take(3).ToList();
            return View(by);
        }

       
        public ActionResult BlogDetay(int id) 
        {
           
           // var BlogBul = c.Blogs.Where(x => x.ID == id).ToList();
           by.Deger1=c.Blogs.Where(x=> x.ID==id).ToList();
            by.Deger2 = c.Yorums.Where(x => x.BlogID == id).ToList();
            return View(by);
          
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
       public PartialViewResult YorumYap(Yorum y)
           {
            c.Yorums.Add(y);
            c.SaveChanges();
            return PartialView(c);
            }

         
       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel_Projesi.Models.Siniflar;

namespace Travel_Projesi.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();


        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var blg = c.Blogs.Find(id);
            return View("BlogGetir", blg);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var bl = c.Blogs.Find(b.ID);
            bl.Aciklama = b.Aciklama;
            bl.Baslik = b.Baslik;
            bl.BlogImage = b.BlogImage;
            bl.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorum = c.Yorums.ToList();
            return View(yorum);
        }
        public ActionResult YorumSil(int id)
        {
            var b = c.Yorums.Find(id);
            c.Yorums.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var yrm = c.Yorums.Find(id);
            return View("YorumGetir", yrm);
        }
        public ActionResult YorumGuncelle(Yorum y)
        {
            var yrm = c.Yorums.Find(y.ID);
            yrm.KullaniciAdi = y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorumlar = y.Yorumlar;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult İletisimListesi()
        {
            var iletisim = c.İletisims.ToList();
            return View(iletisim);
        }
      
        public ActionResult İletisimGuncelle(int id)
        {
            var iltsm = c.İletisims.Find(id);            
            return View("İletisimGuncelle",iltsm);
            
        }
        [HttpGet]

        public ActionResult Yeniİletisim()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Yeniİletisim(İletisim p)
        {

            c.İletisims.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult İletisimSil(int id)
        {
            var b = c.İletisims.Find(id);
            c.İletisims.Remove(b);
            c.SaveChanges();
            return RedirectToAction("İletisimListesi");
        }
        public ActionResult HakkindaListesi()
        {
            var hakkinda = c.Hakkimizdas.ToList();
            return View(hakkinda);
        }

        [HttpGet]
        
        public ActionResult YeniHakkimda()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniHakkimda( Hakkimizda h)
        {
            c.Hakkimizdas.Add(h);
            c.SaveChanges();
            return RedirectToAction("HakkindaListesi");
        }

        public ActionResult HakkimdaSil(int id)
        {
            var hak = c.Hakkimizdas.Find(id);
            c.Hakkimizdas.Remove(hak);
            c.SaveChanges();        
            return RedirectToAction("HakkindaListesi");   
        }
        public ActionResult HakkimdaGetir(int id)
        {
            var hakkimda = c.Hakkimizdas.Find(id);
            return View("HakkimdaGetir", hakkimda);
        }

        public ActionResult HakkimdaGuncelle(Hakkimizda h)
        {
            var hak = c.Hakkimizdas.Find(h.ID);
            hak.Aciklama = h.Aciklama;
            hak.FotoUrl= h.FotoUrl;
            c.SaveChanges();
            return RedirectToAction("HakkindaListesi",hak);
        }

    }
}
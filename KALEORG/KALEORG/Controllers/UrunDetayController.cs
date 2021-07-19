using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;

// using System.Drawing;    FOTO EKLEMEK İÇİN KULLANILAN BİR KÜTÜPHANE MİDİR ?


namespace KALEORG.Controllers
{
    public class UrunDetayController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: UrunDetay
       

        public ActionResult Index(int id)
        {
            MenuList();
            ViewBag.SonAranan = SonAranan();
            List<UrunYorumMusteri_Result> search = et.UrunYorumMusteri(1).Where(q => q.URUN_ID == id).OrderByDescending(q => q.URUN_YORUM_ID).ToList();
            ViewBag.RUrunList = UrunDetayRandom();
            ViewBag.searchUrun = et.T_URUN.Where(q => q.URUN_ID == id).FirstOrDefault();
            ViewBag.UrunFoto = et.T_URUN_FOTO.Where(q => q.URUN_ID == id).ToList();
            ViewBag.UrunOy = int.Parse(et.T_URUN_YORUM.Where(m => m.URUN_ID == id && m.KAPALI == true).Sum(q => q.YILDIZ).ToString());
            ViewBag.YorumSayi = int.Parse(et.T_URUN_YORUM.Where(m => m.URUN_ID == id && m.KAPALI == true).Count(q => q.YORUM != null).ToString());
            ViewBag.RandomUrun = UrunDetayRandom();
            return View(search);
        }
        
        [HttpPost]
        public ActionResult Save(string fname, string email, string comment, int puan, int urunId)
        {
            MenuList();
            
            try
            {                
                
                T_URUN_YORUM yeniYorum = new T_URUN_YORUM();
                
                yeniYorum.URUN_ID = urunId;
                yeniYorum.YORUM = comment;
                yeniYorum.YORUM_AD_SOYAD = fname;
                yeniYorum.YORUM_MAIL = email;
                yeniYorum.YILDIZ = puan;
                yeniYorum.KAPALI = false;
                yeniYorum.GUNCELLEME_TARIHI = DateTime.Now;
                et.T_URUN_YORUM.Add(yeniYorum);
                et.SaveChanges();
                return RedirectToAction("Index", "UrunDetay",new { id=urunId});

            }
            catch (Exception)
            {

                TempData["alert"] = "<script>alert('HATA OLUŞTU.');</script>";
                return RedirectToAction("Index", "UrunDetay", new { id = urunId });
            }
            
        }
    }
}
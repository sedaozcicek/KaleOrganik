using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KALEORG.Models;


namespace KALEORG.Controllers
{
    public class SiparisController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Siparis
        public ActionResult Index()
        {
            MenuList();
            List<T_URUN_SEPET> newList = new List<T_URUN_SEPET>();
            decimal genelToplam = 0;
            
            if (Session["Sepet"] != null)
            {
                List<T_URUN_SEPET> sepet = (List<T_URUN_SEPET>)Session["Sepet"];
                foreach (var i in sepet)
                {
                    T_URUN_SEPET u = new T_URUN_SEPET();
                    u.URUN_ADI = i.URUN_ADI;
                    u.URUN_ID = i.URUN_ID;
                    u.FOTO = i.FOTO;
                    u.URUN_FIYAT = i.URUN_FIYAT;
                    u.MIKTAR = i.MIKTAR;
                    
                    genelToplam = genelToplam + (i.URUN_FIYAT * i.MIKTAR);
                    newList.Add(u);
                }
            }
            ViewBag.GenelToplam = genelToplam;
            
            return View(newList);
        }

        public ActionResult Save(T_MUSTERI musteri, string ad, string soyad, string email, string telefon, 
                                 string ulke,string il,string ilce, string postak, string adres)
        {
            MenuList();
            //Müşteriyi kaydetmek için.
            T_MUSTERI yeniMusteri = new T_MUSTERI();
            yeniMusteri.MUSTERI_ADI = ad;
            yeniMusteri.MUSTERI_SOYADI = soyad;
            yeniMusteri.MUSTERI_MAIL = email;
            yeniMusteri.MUSTERI_TELEFON = telefon;
            yeniMusteri.GUNCELLEME_TARIHI = System.DateTime.Now;
            yeniMusteri.KAPALI = true;
            et.T_MUSTERI.Add(yeniMusteri);
            //et.SaveChanges();


            //Müşterinin adresini kaydetmek için
            T_URUN_SEPET n = new T_URUN_SEPET();
            
            
            T_ADRES a = new T_ADRES();
            a.MUSTERI_ID = yeniMusteri.MUSTERI_ID;
            a.IL = il;
            a.ULKE = ulke;
            a.ILCE = ilce;
            a.ADRES = adres;
            et.T_ADRES.Add(a);
            et.SaveChanges();

            //List<T_URUN_SEPET> sepet = (List<T_URUN_SEPET>)Session["Sepet"];
            //foreach (var i in sepet)
            //{
            //    T_URUN_SATIS u = new T_URUN_SATIS();
            //    u.MUSTERI_ID = yeniMusteri.MUSTERI_ID;
            //    u.URUN_ID = i.URUN_ID;
            //    u.FOTO = i.FOTO;
            //    u.URUN_FIYAT = i.URUN_FIYAT;
            //    u.MIKTAR = i.MIKTAR;

            //    genelToplam = genelToplam + (i.URUN_FIYAT * i.MIKTAR);
            //    et.SaveChanges(u)
            //}



            return View();
        }
        

    }
}


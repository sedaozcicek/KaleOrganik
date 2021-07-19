using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;
using KALEORG.Controllers;

namespace KALEORG.Areas.Admin.Controllers
{
    public class SiparisAdminController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Admin/SiparisAdmin
        public ActionResult Index()
        {
            try
            {
                if (getRolesKontrol(SiparisListele) == true)
                {
                    List<Sepet_Result> siparisList = et.Sepet(1).ToList();
                    return View(siparisList);
                }
                else
                {
                    return RedirectToAction("Index", "HomeAdmin");
                }
               
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult SiparisForm()
        {
            if (getRolesKontrol(SiparisUpdate) == true)
            {
                List<T_MUSTERI> musteriList = et.T_MUSTERI.Where(q => q.KAPALI == true).ToList();
                musteriSelect();
                adresSelect();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "HomeAdmin");
            }

        }
        public ActionResult Update(int id)
        {
            try
            {
                if (getRolesKontrol(SiparisUpdate) == true)
                {
                    T_SIPARIS search = et.T_SIPARIS.Where(q => q.SIPARIS_ID == id).FirstOrDefault();
                    //Müşteri için
                    musteriSelect();
                    //Adres için
                    adresSelect();
                    //Ürün Satış için
                    urunSatisSelect();
                    search.SIPARIS_TARIHI = DateTime.Now;
                    search.KAPALI = true;
                    return View("SiparisForm", search);
                }
                else
                {
                    return RedirectToAction("Index", "SiparisAdmin");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult Save(T_SIPARIS siparis)
        {
            try
            {
                if (siparis.SIPARIS_ID == 0)
                {
                    T_SIPARIS s = new T_SIPARIS();
                    s.MUSTERI_ID = siparis.MUSTERI_ID;
                    s.ADRES_ID = siparis.ADRES_ID;
                    s.URUN_ID = siparis.URUN_ID;
                    s.KARGO_FIRMA_ID = siparis.KARGO_FIRMA_ID;
                    s.URUN_SATIS_ID = siparis.URUN_SATIS_ID;                   
                    s.SIPARIS_TARIHI = DateTime.Now;
                    s.KAPALI = true;
                    et.T_SIPARIS.Add(s);
                    et.SaveChanges();
                }
                else
                {
                    T_SIPARIS s = et.T_SIPARIS.Where(q => q.KAPALI==true && q.SIPARIS_ID == siparis.SIPARIS_ID).FirstOrDefault();
                    s.MUSTERI_ID = siparis.MUSTERI_ID;
                    s.ADRES_ID = siparis.ADRES_ID;
                    s.URUN_ID = siparis.URUN_ID;
                    s.KARGO_FIRMA_ID = siparis.KARGO_FIRMA_ID;
                    s.URUN_SATIS_ID = siparis.URUN_SATIS_ID;
                    s.SIPARIS_TARIHI = DateTime.Now;
                    s.KAPALI = true;
                    et.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult Passive(int id)
        {
            try
            {
                if (getRolesKontrol(SiparisPasive) == true)
                {
                    T_SIPARIS search = et.T_SIPARIS.Where(q => q.KAPALI == true && q.SIPARIS_ID == id).FirstOrDefault();
                    search.KAPALI = false;
                    search.SIPARIS_TARIHI = DateTime.Now;
                    et.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "SiparisAdmin");
                }
            }
            catch (Exception ex)
            {

                throw;

            }
        }
        public ActionResult PassiveList()
        {
            try
            {
                if (getRolesKontrol(SiparisListele) == true)
                {
                    List<Sepet_Result> siparisList = et.Sepet(0).ToList();
                    ViewBag.Ekran = "Pasif";
                    return View("Index", siparisList);
                }
                else
                {
                    return RedirectToAction("Index", "SiparisAdmin");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult Active(int id)
        {
            try
            {
                if (getRolesKontrol(UrunActive) == true)
                {
                    T_URUN search = et.T_URUN.Where(q => q.KAPALI == false && q.URUN_ID == id).FirstOrDefault();
                    search.KAPALI = true;
                    search.GUNCELLEME_TARIHI = DateTime.Now;
                    et.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "UrunAdmin");
                }
            }
            catch (Exception ex)
            {

                throw;

            }
        }

    }
}
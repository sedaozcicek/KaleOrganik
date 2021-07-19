using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;
using KALEORG.Controllers;

namespace KALEORG.Areas.Admin.Controllers
{
    public class UrunSatisAdminController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Admin/UrunSatisAdmin
        public ActionResult Index()
        {
            try
            {
                if (getRolesKontrol(UrunSatisListele) == true)
                {
                    List<UrunSatisUrunMusteri_Result> urunList = et.UrunSatisUrunMusteri(1).ToList();
                    return View(urunList);
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
        public ActionResult UrunSatisForm()
        {
            if (getRolesKontrol(UrunSatisEkle) == true)
            {
                urunSelect();
                musteriSelect();
                kargoSelect();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "HomeAdmin");
            }
        }       
        public ActionResult Save(T_URUN_SATIS urunSatis)
        {
            
            try
            {
                if (urunSatis.URUN_SATIS_ID == 0)
                {
                    T_URUN_SATIS us = new T_URUN_SATIS();
                    us.URUN_ID = urunSatis.URUN_ID;
                    us.SATIS_TARIHI = urunSatis.SATIS_TARIHI;
                    us.MUSTERI_ID = urunSatis.MUSTERI_ID;
                    us.KARGO_FIRMA_ID = urunSatis.KARGO_FIRMA_ID;
                    us.KARGO_NO = urunSatis.KARGO_NO;
                    us.MIKTAR = urunSatis.MIKTAR;
                    us.SATIS_FIYAT = urunSatis.SATIS_FIYAT;
                    us.KAPALI = true;
                    us.GUNCELLEME_TARIHI = DateTime.Now;
                    et.T_URUN_SATIS.Add(us);
                    et.SaveChanges();
                }
                else
                {
                    T_URUN_SATIS us = et.T_URUN_SATIS.Where(q => q.KAPALI == true).FirstOrDefault();
                    us.URUN_ID = urunSatis.URUN_ID;
                    us.SATIS_TARIHI = urunSatis.SATIS_TARIHI;
                    us.MUSTERI_ID = urunSatis.MUSTERI_ID;
                    us.KARGO_FIRMA_ID = urunSatis.KARGO_FIRMA_ID;
                    us.KARGO_NO = urunSatis.KARGO_NO;
                    us.MIKTAR = urunSatis.MIKTAR;
                    us.SATIS_FIYAT = urunSatis.SATIS_FIYAT;
                    us.KAPALI = true;
                    us.GUNCELLEME_TARIHI = DateTime.Now;
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
                if (getRolesKontrol(UrunSatisPassive) == true)
                {
                    T_URUN_SATIS search = et.T_URUN_SATIS.Where(q => q.KAPALI == true && q.URUN_ID == id).FirstOrDefault();
                    search.KAPALI = false;
                    search.GUNCELLEME_TARIHI = DateTime.Now;
                    et.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "UrunSatisAdmin");
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
                if (getRolesKontrol(UrunSatisPassiveList) == true)
                {
                    List<UrunSatisUrunMusteri_Result> urunSatisList = et.UrunSatisUrunMusteri(0).ToList();
                    ViewBag.Ekran = "Pasif";
                    return View("Index", urunSatisList);
                }
                else
                {
                    return RedirectToAction("Index", "UrunSatisAdmin");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult Update(int id)
        {
            try
            {
                if (getRolesKontrol(UrunSatisUpdate) == true)
                {
                    T_URUN_SATIS search = et.T_URUN_SATIS.Where(q => q.KAPALI == true && q.URUN_SATIS_ID == id).FirstOrDefault();

                    urunSelect();
                    musteriSelect();
                    kargoSelect();

                    return View("UrunSatisForm", search);
                }
                else
                {
                    return RedirectToAction("Index", "UrunSatisAdmin");
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
                if (getRolesKontrol(UrunSatisActive) == true)
                {
                    T_URUN_SATIS search = et.T_URUN_SATIS.Where(q => q.KAPALI == false && q.URUN_ID == id).FirstOrDefault();
                    search.KAPALI = true;
                    search.GUNCELLEME_TARIHI = DateTime.Now;
                    et.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "UrunSatisAdmin");
                }
            }
            catch (Exception ex)
            {

                throw;

            }
        }
    }
}
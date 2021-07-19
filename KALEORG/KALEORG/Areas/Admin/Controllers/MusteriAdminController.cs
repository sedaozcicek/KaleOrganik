using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;
using KALEORG.Controllers;

namespace KALEORG.Areas.Admin.Controllers
{
    public class MusteriAdminController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Admin/MusteriAdmin
        public ActionResult Index()
        {
            try
            {
                if (getRolesKontrol(MusteriListele) == true)
                {
                    List<T_MUSTERI> musteriList = et.T_MUSTERI.Where(q => q.KAPALI == true).ToList();
                    ViewBag.Ekran = "Aktif";
                    return View(musteriList);
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
        public ActionResult Passive(int id)
        {
            try
            {
                if (getRolesKontrol(MusteriPassive) == true)
                {
                    T_MUSTERI search = et.T_MUSTERI.Where(q => q.KAPALI == true && q.MUSTERI_ID == id).FirstOrDefault();
                    search.KAPALI = false;
                    search.GUNCELLEME_TARIHI = DateTime.Now;
                    et.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "MusteriAdmin");
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
                if (getRolesKontrol(MusteriPassiveList) == true)
                {
                    List<T_MUSTERI> musteriList = et.T_MUSTERI.Where(q => q.KAPALI == false).ToList();
                    ViewBag.Ekran = "Pasif";
                    return View("Index", musteriList);
                }
                else
                {
                    return RedirectToAction("Index", "MusteriAdmin");
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
                if (getRolesKontrol(MusteriActive) == true)
                {
                    T_MUSTERI search = et.T_MUSTERI.Where(q => q.KAPALI == false && q.MUSTERI_ID == id).FirstOrDefault();
                    search.KAPALI = true;
                    search.GUNCELLEME_TARIHI = DateTime.Now;
                    et.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "MusteriAdmin");
                }
            }
            catch (Exception ex)
            {

                throw;

            }
        }
        public ActionResult MusteriForm()
            {
             if (getRolesKontrol(MusteriEkle) == true)
             {
                return View();
             }
            else
            {
                return RedirectToAction("Index", "HomeAdmin");
            }
            }
        public ActionResult Save(T_MUSTERI musteri)
            {
                if (musteri.MUSTERI_ID == 0)
                {
                    T_MUSTERI m = new T_MUSTERI();
                    m.MUSTERI_ADI = musteri.MUSTERI_ADI;
                    m.MUSTERI_SOYADI = musteri.MUSTERI_SOYADI;
                    m.MUSTERI_MAIL = musteri.MUSTERI_MAIL;
                    m.MUSTERI_TELEFON = musteri.MUSTERI_TELEFON;
                    m.KAPALI = true;
                    m.GUNCELLEME_TARIHI = DateTime.Now;
                    et.T_MUSTERI.Add(m);
                    et.SaveChanges();
                }
                else
                {
                    T_MUSTERI search = et.T_MUSTERI.Where(q => q.KAPALI == true && q.MUSTERI_ID == musteri.MUSTERI_ID).FirstOrDefault();
                    search.MUSTERI_ADI = musteri.MUSTERI_ADI;
                    search.MUSTERI_SOYADI = musteri.MUSTERI_SOYADI;
                    search.MUSTERI_MAIL = musteri.MUSTERI_MAIL;
                    search.MUSTERI_TELEFON = musteri.MUSTERI_TELEFON;
                    search.KAPALI = true;
                    search.GUNCELLEME_TARIHI = DateTime.Now;
                    et.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        public ActionResult Update(int id)
            {
                try
                {
                if (getRolesKontrol(MusteriUpdate) == true)
                {
                    T_MUSTERI search = et.T_MUSTERI.Where(q => q.KAPALI == true && q.MUSTERI_ID == id).FirstOrDefault();
                    musteriSelect();
                    return View("MusteriForm", search);
                }
                else
                {
                    return RedirectToAction("Index", "MusteriAdmin");
                }
            }
                catch (Exception ex)
                {

                    throw;
                }
            }
      

    }
}

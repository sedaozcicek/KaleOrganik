using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Controllers;
using KALEORG.Models;

namespace KALEORG.Areas.Admin.Controllers
{
    public class KategoriAdminController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        
        // GET: Admin/KategoriAdmin
        public ActionResult Index()
        {
            if (getRolesKontrol(MailListele)==true)
            {
                try
                {
                    if (getRolesKontrol(KategoriListele) == true)
                    {
                        List<T_KATEGORI> kategoriList = et.T_KATEGORI.Where(q => q.KAPALI == true).ToList();
                        return View(kategoriList);
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
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Passive(int id)
        {
            try
            {
                if (getRolesKontrol(KategoriPassive) == true)
                {
                    T_KATEGORI search = et.T_KATEGORI.Where(q => q.KAPALI == true && q.KATEGORI_ID == id).FirstOrDefault();
                    search.KAPALI = false;
                    search.GUNCELLEME_TARIHI = DateTime.Now;
                    et.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "KategoriAdmin");
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
                if (getRolesKontrol(KategoriPassiveList) == true)
                {
                    List<T_KATEGORI> kategoriList = et.T_KATEGORI.Where(q => q.KAPALI == false).ToList();
                    ViewBag.Ekran = "Pasif";
                    return View("Index", kategoriList);
                }
                else
                {
                    return RedirectToAction("Index", "KategoriAdmin");
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
                if (getRolesKontrol(KategoriActive) == true)
                {
                    T_KATEGORI search = et.T_KATEGORI.Where(q => q.KAPALI == false && q.KATEGORI_ID == id).FirstOrDefault();
                    search.KAPALI = true;
                    search.GUNCELLEME_TARIHI = DateTime.Now;
                    et.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "KategoriAdmin");
                }
            }
            catch (Exception ex)
            {

                throw;

            }
        }
        public ActionResult KategoriForm()
        {
            if (getRolesKontrol(KategoriEkle) == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "HomeAdmin");
            }
           
        }
        public ActionResult Save(T_KATEGORI kategori)
        {
            try
            {
                if (kategori.KATEGORI_ID == 0)
                {
                    T_KATEGORI k = new T_KATEGORI();
                    k.KATEGORI_ADI = kategori.KATEGORI_ADI;
                    k.KAPALI = true;
                    k.GUNCELLEME_TARIHI = DateTime.Now;
                    et.T_KATEGORI.Add(k);
                    et.SaveChanges();
                }
                else
                {
                    T_KATEGORI k = et.T_KATEGORI.Where(q => q.KAPALI == true && q.KATEGORI_ID == kategori.KATEGORI_ID).FirstOrDefault();
                    k.KATEGORI_ADI = kategori.KATEGORI_ADI;
                    k.KAPALI = true;
                    k.GUNCELLEME_TARIHI = DateTime.Now;
                    et.SaveChanges();
                }
               
                return RedirectToAction("Index");
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
                if (getRolesKontrol(KategoriUpdate) == true)
                {
                    T_KATEGORI search = et.T_KATEGORI.Where(q => q.KAPALI == true && q.KATEGORI_ID == id).FirstOrDefault();

                    kategoriSelect();
                    return View("KategoriForm", search);
                }
                else
                {
                    return RedirectToAction("Index", "KategoriAdmin");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
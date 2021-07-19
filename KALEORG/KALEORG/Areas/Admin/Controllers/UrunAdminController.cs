using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Controllers;
using KALEORG.Models;

namespace KALEORG.Areas.Admin.Controllers
{
    public class UrunAdminController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Admin/UrunAdmin
        public ActionResult Index()
        {
            try
            {
                if (getRolesKontrol(UrunListele) == true)
                {
                    List<UrunKategoriList_Result> urunList = et.UrunKategoriList(1).ToList();
                    ViewBag.Ekran = "Aktif";
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
        public ActionResult PassiveList()
        {

            try
            {
                if (getRolesKontrol(UrunPassiveList) == true)
                {
                    List<UrunKategoriList_Result> urunList = et.UrunKategoriList(0).ToList();
                    ViewBag.Ekran = "Pasif";
                    return View("Index", urunList);
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
        public ActionResult UrunForm()
        {
            if (getRolesKontrol(UrunEkle) == true)
            {
                kategoriSelect();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "HomeAdmin");
            }

        }
        public ActionResult Save(T_URUN urun, HttpPostedFileBase uploadfile)
        {

            try
            {
                if (urun.URUN_ID == 0)
                {
                    if (uploadfile.ContentLength > 0)
                    {
                        string filePath = Path.Combine(Server.MapPath("~/img/urun/"), Guid.NewGuid().ToString() + "_" + uploadfile.FileName);
                        uploadfile.SaveAs(filePath);

                        string resimAdi = filePath.Split('\\').Last();

                        urun.FOTO = resimAdi;
                        urun.KAPALI = true;
                        urun.GUNCELLEME_TARIHI = DateTime.Now;
                    }

                    et.T_URUN.Add(urun);
                    et.SaveChanges();
                }
                else
                {
                    T_URUN u = et.T_URUN.Where(q => q.URUN_ID == urun.URUN_ID).FirstOrDefault();
                    if (u != null)
                    {
                        if (urun.FOTO != null)
                        {
                            System.IO.File.Delete(Server.MapPath("~/img/urun/" + urun.FOTO));
                        }

                        u.KATEGORI_ID = urun.KATEGORI_ID;
                        u.URUN_ADI = urun.URUN_ADI;
                        u.URUN_FIYAT = urun.URUN_FIYAT;
                        string filePath = Path.Combine(Server.MapPath("~/img/"), Guid.NewGuid().ToString() + "_" + uploadfile.FileName);
                        uploadfile.SaveAs(filePath);
                        string resimAdi = filePath.Split('\\').Last();
                        u.FOTO = resimAdi;
                        u.ACIKLAMA = urun.ACIKLAMA;
                        u.KAPALI = true;
                        urun.GUNCELLEME_TARIHI = DateTime.Now;
                        et.SaveChanges();


                    }
                    else
                    {
                        ;
                    }
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
                if (getRolesKontrol(UrunUpdate) == true)
                {
                    T_URUN search = et.T_URUN.Where(q => q.URUN_ID == id).FirstOrDefault();
                    kategoriSelect();
                    return View("UrunForm", search);
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
        public ActionResult Passive(int id)
        {
            try
            {
                if (getRolesKontrol(UrunPassive) == true)
                {
                    T_URUN search = et.T_URUN.Where(q => q.KAPALI == true && q.URUN_ID == id).FirstOrDefault();
                    search.KAPALI = false;
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
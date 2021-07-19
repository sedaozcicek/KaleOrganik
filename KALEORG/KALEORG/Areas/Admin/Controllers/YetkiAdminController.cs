using KALEORG.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;

namespace KALEORG.Areas.Admin.Controllers
{
    public class YetkiAdminController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Admin/YetkiAdmin
        public ActionResult Index()
        {
            if (getRolesKontrol(YetkiListeleme)==true)
            {

                List<T_KULLANICI> kullaniciList = et.T_KULLANICI.ToList();
                List<SelectListItem> kullaniciSelect = new List<SelectListItem>();
                kullaniciSelect.Add(new SelectListItem { Text = "Lütfen seçiniz..", Value = " " });
                foreach (var i in kullaniciList)
                {
                    kullaniciSelect.Add(new SelectListItem { Text = i.Kullanici_Adi, Value = i.Kullanici_ID.ToString() });
                }
                ViewBag.user = kullaniciSelect;

                return View();
            }

            else
            {
                return RedirectToAction("Index", "HomeAdmin");
            }
            
            
        }
        public ActionResult Arama(int KULLANICI)
        {
            if (getRolesKontrol(YetkiListeleme) == true)
            {
                try
                {
                    List<T_KULLANICI> kullaniciList = et.T_KULLANICI.ToList();
                    List<SelectListItem> kullaniciSelect = new List<SelectListItem>();
                    kullaniciSelect.Add(new SelectListItem { Text = "Lütfen seçiniz..", Value = " " });
                    foreach (var i in kullaniciList)
                    {
                        kullaniciSelect.Add(new SelectListItem { Text = i.Kullanici_Adi, Value = i.Kullanici_ID.ToString() });
                    }
                    ViewBag.user = kullaniciSelect;
                    List<KULLANICI_KATEGORI> KullaniciKategoriList = et.KULLANICI_KATEGORI.Where(q => q.KULLANICI_ID == KULLANICI).ToList();
                    return View("Index", KullaniciKategoriList);
                }
                catch
                {
                    return RedirectToAction("Index", "LoginAdmin");
                }
            }
            else
            {
                return RedirectToAction("Index", "HomeAdmin");
            }
           
           
        }
        [HttpPost]
        public JsonResult YetkiGuncelle(int usrId, int categoryId, int flag)
        {
            if (getRolesKontrol(YetkiListeleme) == true)
            {

                if (flag == 1)
                {
                    KULLANICI_KATEGORI k = new KULLANICI_KATEGORI();
                    k.KULLANICI_ID = usrId;
                    k.KATEGORI = categoryId;
                    et.KULLANICI_KATEGORI.Add(k);
                    et.SaveChanges();
                    return Json(new { sonuc = true }, JsonRequestBehavior.AllowGet);
                }
           
                else
                {
                    KULLANICI_KATEGORI search = et.KULLANICI_KATEGORI.Where(q => q.KATEGORI == categoryId && q.KULLANICI_ID == usrId).FirstOrDefault();
                    if (search != null)
                    {
                        et.KULLANICI_KATEGORI.Remove(search);
                        et.SaveChanges();
                        return Json(new { sonuc = true }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { sonuc = false }, JsonRequestBehavior.AllowGet);
                    }
                }
             }
            else
            {
                return Json(new { sonuc = false }, JsonRequestBehavior.AllowGet);
            }



        }
    }
}
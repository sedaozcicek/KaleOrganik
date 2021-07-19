using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;
using KALEORG.Controllers;

namespace KALEORG.Areas.Admin.Controllers
{
    public class YorumAdminController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Admin/YorumAdmin
        public ActionResult Index()
        {

            try
            {
                if (getRolesKontrol(YorumListele) == true)
                {
                    List<UrunYorumMusteri_Result> yorumList = et.UrunYorumMusteri(1).OrderByDescending(q=>q.URUN_YORUM_ID).ToList(); //en son yapılan yorum en basa geçmesi için orderbydescending kullandık
                    ViewBag.Ekran = "Aktif";
                    return View(yorumList);
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
                if (getRolesKontrol(YorumPassive) == true)
                {
                    
                    T_URUN_YORUM search = et.T_URUN_YORUM.Where(q => q.KAPALI == true && q.URUN_YORUM_ID == id).FirstOrDefault();
                    search.KAPALI = false;
                    search.GUNCELLEME_TARIHI = DateTime.Now;
                    et.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "YorumAdmin");
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
                if (getRolesKontrol(YorumPassiveList) == true)
                {
                    List<UrunYorumMusteri_Result> yorumList = et.UrunYorumMusteri(0).OrderByDescending(q => q.URUN_YORUM_ID).ToList();
                    ViewBag.Ekran = "Pasif";
                    return View("Index", yorumList);
                }
                else
                {
                    return RedirectToAction("Index", "YorumAdmin");
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
                if (getRolesKontrol(YorumActive) == true)
                {
                    T_URUN_YORUM search = et.T_URUN_YORUM.Where(q => q.KAPALI == false && q.URUN_YORUM_ID == id).FirstOrDefault();
                    search.KAPALI = true;
                    search.GUNCELLEME_TARIHI = DateTime.Now;
                    et.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "YorumAdmin");
                }
            }
            catch (Exception ex)
            {

                throw;

            }
        }
        
    }
}
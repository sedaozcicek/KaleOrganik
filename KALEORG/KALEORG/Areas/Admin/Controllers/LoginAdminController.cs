using KALEORG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KALEORG.Controllers;

namespace KALEORG.Areas.Admin.Controllers
{
    public class LoginAdminController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Admin/LoginAdmin        
        public ActionResult Index()
            
        {
            return View();
        }
        public ActionResult Giris(T_KULLANICI k)
        {
            try
            {
                T_KULLANICI search = et.T_KULLANICI.Where(q => q.Kullanici_Adi == k.Kullanici_Adi && q.Sifre == k.Sifre).FirstOrDefault();
                if (search != null)
                {
                    Session["User"] = search;

                    List<KULLANICI_KATEGORI> yetkiList = et.KULLANICI_KATEGORI.Where(q => q.KULLANICI_ID == search.Kullanici_ID).ToList();
                    Session["Yetki"] = yetkiList;

                    FormsAuthentication.SetAuthCookie(search.Kullanici_Adi, false);
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else
                {                    
                    return RedirectToAction("Index", "LoginAdmin");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "LoginAdmin");
        }
    }
}
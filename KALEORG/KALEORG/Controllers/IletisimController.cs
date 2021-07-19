using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;
using KALEORG.Controllers;

namespace KALEORG.Controllers
{
    public class IletisimController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Iletisim
        public ActionResult Index()
        {
            MenuList();
            return View();
        }
        public ActionResult Save(string fname, string lname, string email, string konu, string mesaj)
        {
            MenuList();
            try
            {
                T_MAIL yeniMail = new T_MAIL();
                yeniMail.MAIL_AD = fname;
                yeniMail.MAIL_SOYAD = lname;
                yeniMail.MAIL_ADRES = email;
                yeniMail.MAIL_KONU = konu;
                yeniMail.MAIL_ICERIK = mesaj;
                yeniMail.MAIL_GUNCELLEME_TARIHI = DateTime.Now;
                et.T_MAIL.Add(yeniMail);
                et.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {


                TempData["alert"] = "<script>alert('HATA OLUŞTU.');</script>";
                return RedirectToAction("Index", "Iletisim");
            }

        }
    }
}
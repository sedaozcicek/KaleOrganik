 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;
using KALEORG.Controllers;

namespace KALEORG.Areas.Admin.Controllers
{
    public class IletisimAdminController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Admin/IletisimAdmin
        public ActionResult Index()
        {
            try
            {
                if (getRolesKontrol(IletisimListele) == true)
                {
                    List<T_ILETISIM> IletisimList = et.T_ILETISIM.ToList();
                    return View(IletisimList);
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
        public ActionResult Save(T_ILETISIM iletisim)
        {
            if (iletisim.ILETISIM_ID == 0)
            {
                T_ILETISIM m = new T_ILETISIM();
                m.MAIL_INFO = iletisim.MAIL_INFO;
                m.MAIL_MUHASEBE = iletisim.MAIL_MUHASEBE;
                m.MAIL_SATIS = iletisim.MAIL_SATIS;
                m.TELEFON1 = iletisim.TELEFON1;
                m.TELEFON2 = iletisim.TELEFON2;
                m.ADRES = iletisim.ADRES;
                m.FAKS = iletisim.FAKS;
                et.T_ILETISIM.Add(m);
                et.SaveChanges();
            }
            else
            {
                T_ILETISIM m = et.T_ILETISIM.Where(q => q.ILETISIM_ID == iletisim.ILETISIM_ID).FirstOrDefault();
                m.MAIL_INFO = iletisim.MAIL_INFO;
                m.MAIL_MUHASEBE = iletisim.MAIL_MUHASEBE;
                m.MAIL_SATIS = iletisim.MAIL_SATIS;
                m.TELEFON1 = iletisim.TELEFON1;
                m.TELEFON2 = iletisim.TELEFON2;
                m.ADRES = iletisim.ADRES;
                m.FAKS = iletisim.FAKS;
                et.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            try
            {
                if (getRolesKontrol(IletisimUpdate) == true)
                {
                    T_ILETISIM search = et.T_ILETISIM.Where(q => q.ILETISIM_ID == id).FirstOrDefault();
                    iletisimSelect();
                    return View("IletisimForm", search);
                }
                else
                {
                    return RedirectToAction("Index", "IletisimAdmin");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult IletisimForm()
        {
            return View();
        }
    }
}

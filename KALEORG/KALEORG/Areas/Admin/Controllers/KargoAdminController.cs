using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;
using KALEORG.Controllers;

namespace KALEORG.Areas.Admin.Controllers
{
    public class KargoAdminController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Admin/KargoAdmin
        public ActionResult Index()
        {
            try
            {
                if (getRolesKontrol(KargoListele) == true)
                {
                    List<T_KARGO> kargoList = et.T_KARGO.ToList();
                    return View(kargoList);
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
        public ActionResult Save(T_KARGO kargo)
        {
            if (kargo.KARGO_FIRMA_ID == 0)
            {
                T_KARGO m = new T_KARGO();
                m.FIRMA_ADI = kargo.FIRMA_ADI;
                m.SOZLESME_NO = kargo.SOZLESME_NO;
                m.SUBE = kargo.SUBE;
                m.SUBE_NO = kargo.SUBE_NO;
                et.T_KARGO.Add(m);
                et.SaveChanges();
            }
            else
            {
                T_KARGO m = et.T_KARGO.Where(q => q.KARGO_FIRMA_ID == kargo.KARGO_FIRMA_ID ).FirstOrDefault();
                m.FIRMA_ADI = kargo.FIRMA_ADI;
                m.SOZLESME_NO = kargo.SOZLESME_NO;
                m.SUBE = kargo.SUBE;
                m.SUBE_NO = kargo.SUBE_NO;
                et.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            try
            {
                if (getRolesKontrol(KargoUpdate) == true)
                {
                    T_KARGO search = et.T_KARGO.Where(q => q.KARGO_FIRMA_ID == id).FirstOrDefault();
                    kargoSelect();
                    return View("KargoForm", search);
                }
                else
                {
                    return RedirectToAction("Index", "KargoAdmin");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult KargoForm()
        {
            if (getRolesKontrol(KargoEkle) == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "HomeAdmin");
            }
            
        }
    }
}
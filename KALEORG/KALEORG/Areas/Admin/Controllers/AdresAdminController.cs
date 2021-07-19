using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;
using KALEORG.Controllers;

namespace KALEORG.Areas.Admin.Controllers
{
    public class AdresAdminController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Admin/AdresAdmin

        public ActionResult Index(int id)
        {
            try
            {

                if (getRolesKontrol(MusteriAdresListe) == true)
                {
                    List<MusteriAdresList_Result> musteriList = et.MusteriAdresList(id).ToList();
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

       
        public ActionResult PassiveList(int id)
        {
            try
            {
                if (getRolesKontrol(AdresPassiveList) == true)
                {
                    List<MusteriAdresList_Result> adresList = et.MusteriAdresList(0).Where(q => q.ADRES_ID == id).ToList();
                    ViewBag.Ekran = "Pasif";
                    return View("Index", adresList);
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
        public ActionResult AdresForm(int id)
        {

            if (getRolesKontrol(AdresEkle) == true)
            {                
                musteriSelect();
                MusteriAdresList_Result a = new MusteriAdresList_Result();
                T_MUSTERI m = et.T_MUSTERI.Find(id);
                a.MUSTERI_ID = m.MUSTERI_ID;               
                return View(a);
            }
            else
            {
                return RedirectToAction("Index", "HomeAdmin");
            }
        }

        [HttpPost]
        public ActionResult Save(MusteriAdresList_Result adres)
        {
            try
            {
                if (adres.ADRES_ID == 0)
                {
                    T_ADRES a = new T_ADRES();
                    a.MUSTERI_ID = adres.MUSTERI_ID;
                    a.IL = adres.IL;
                    a.ULKE = adres.ULKE;
                    a.ILCE = adres.ILCE;
                    a.ADRES = adres.ADRES;
                    et.T_ADRES.Add(a);
                    et.SaveChanges();
                }
                else
                {
                    T_ADRES a = et.T_ADRES.Where(q => q.ADRES_ID == adres.ADRES_ID).FirstOrDefault();
                    a.MUSTERI_ID = adres.MUSTERI_ID;
                    a.IL = adres.IL;
                    a.ULKE = adres.ULKE;
                    a.ILCE = adres.ILCE;
                    a.ADRES = adres.ADRES;
                    et.T_ADRES.Add(a);
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
                if (getRolesKontrol(AdresUpdate) == true)
                {
                    MusteriAdresList_Result search = et.MusteriAdresList(1).Where(q => q.ADRES_ID == id).FirstOrDefault();
                    musteriSelect();
                    return View("AdresForm", search);
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
                if (getRolesKontrol(AdresActive) == true)
                {
                    List<MusteriAdresList_Result> adresList = et.MusteriAdresList(1).ToList();
                    ViewBag.Ekran = "Aktif";
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
        public ActionResult Passive()
        {
            try
            {
                if (getRolesKontrol(AdresPassive) == true)
                {
                    List<MusteriAdresList_Result> adresList = et.MusteriAdresList(0).ToList();
                    ViewBag.Ekran = "Pasif";
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;
using KALEORG.Controllers;

namespace KALEORG.Controllers
{
    public class SepetController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Sepet
        public ActionResult Index()
        {
            MenuList();
            List<T_URUN_SEPET> newList = new List<T_URUN_SEPET>();
            decimal genelToplam = 0;
            decimal genelMiktar = 0;
            if (Session["Sepet"] != null)
            {
                List<T_URUN_SEPET> sepet = (List<T_URUN_SEPET>)Session["Sepet"];
                foreach (var i in sepet)
                {
                    T_URUN_SEPET u = new T_URUN_SEPET();
                    u.URUN_ADI = i.URUN_ADI;
                    u.URUN_ID = i.URUN_ID;
                    u.FOTO = i.FOTO;
                    u.URUN_FIYAT = i.URUN_FIYAT;
                    u.MIKTAR = i.MIKTAR;
                    genelToplam = genelToplam + (i.URUN_FIYAT * i.MIKTAR);
                    genelMiktar += i.MIKTAR;
                    newList.Add(u);
                }
                
            }

            UrunKgSelect();
            ViewBag.randomUrunList = randonUrunList();
            ViewBag.genelToplam = genelToplam;
            ViewBag.Kargo = (genelToplam * 10) / 100;
            ViewBag.GenelMiktar = genelMiktar;
            return View(newList);
        }



        public JsonResult SepetDurumGuncelle(int urunid, decimal urunmiktar)
        {
            List<T_URUN_SEPET> sepet = (List<T_URUN_SEPET>)Session["Sepet"];
            decimal genelToplam = 0;
            foreach (var i in sepet)
            {
                if (i.URUN_ID == urunid)
                {
                    i.MIKTAR = urunmiktar;                    
                }
            }
            foreach (var i in sepet)
            {
                genelToplam = genelToplam + (i.URUN_FIYAT * i.MIKTAR);
            }
            
            Session["Sepet"] = sepet;
            return Json(genelToplam, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UrunSil(int id)
        {
            
            List<T_URUN_SEPET> sepet = (List<T_URUN_SEPET>)Session["Sepet"];
            
            for (int i = 0; i < sepet.Count; i++)
            {
                if (sepet[i].URUN_ID == id)
                {

                    sepet.Remove(sepet[i]);

                }
            }
            decimal genelToplam = 0;
            foreach (var i in sepet)
            {
                genelToplam = genelToplam + (i.URUN_FIYAT * i.MIKTAR);
            }

            ViewBag.genelToplam = genelToplam;
            ViewBag.Kargo = (genelToplam * 10) / 100;
            Session["Sepet"] = sepet;


            return RedirectToAction("Index");

        }


    }
}



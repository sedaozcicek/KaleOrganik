using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;
using KALEORG.Controllers;

namespace KALEORG.Areas.Admin.Controllers
{
    public class HakkimizdaAdminController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();

        // GET: Admin/HakkimizdaAdmin
        public ActionResult Index()
        {
            
            try
            {
                if (getRolesKontrol(HakkimizdaListele) == true)
                {
                    List<T_HAKKIMIZDA> kategoriList = et.T_HAKKIMIZDA.ToList();
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
        public ActionResult HakkimizdaForm()
        {
            if (getRolesKontrol(HakkimizdaEkle) == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "HomeAdmin");
            }
            
        }
        public ActionResult Save(T_HAKKIMIZDA hakkımızda)
        {
            if(hakkımızda.HAKKIMIZDA_ID == 0)
            {
                T_HAKKIMIZDA h = new T_HAKKIMIZDA();
                h.HAKKIMIZDA_ICERIK = hakkımızda.HAKKIMIZDA_ICERIK;
                et.T_HAKKIMIZDA.Add(h);
                et.SaveChanges();
            }
            else
            {
                T_HAKKIMIZDA h = et.T_HAKKIMIZDA.Where(q => q.HAKKIMIZDA_ID == hakkımızda.HAKKIMIZDA_ID).FirstOrDefault();
                h.HAKKIMIZDA_ICERIK = hakkımızda.HAKKIMIZDA_ICERIK;
                et.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            try
            {
                if (getRolesKontrol(HakkimizdaUpdate) == true)
                {
                    T_HAKKIMIZDA search = et.T_HAKKIMIZDA.Where(q => q.HAKKIMIZDA_ID == id).FirstOrDefault();
                    hakkimizdaSelect();
                    return View("HakkimizdaForm", search);
                }
                else
                {
                    return RedirectToAction("Index", "HakkimizdaAdmin");
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
                if (getRolesKontrol(HakkimizdaActive) == true)
                {
                    T_HAKKIMIZDA search = et.T_HAKKIMIZDA.Where(q => q.HAKKIMIZDA_ID == id).FirstOrDefault();
                    et.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "HakkimizdaAdmin");
                }
                
            }
            catch (Exception ex)
            {

                throw;

            }
        }
    }
}
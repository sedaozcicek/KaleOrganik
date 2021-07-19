using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG;
using KALEORG.Models;
using KALEORG.Controllers;
using KALEORG.Areas.Admin.Models;
using System.IO;

namespace KALEORG.Areas.Admin.Controllers
{
    public class UrunFotoController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Admin/UrunFoto
        public ActionResult Index()
        {
            List<UrunAdFoto_Result> ufList = et.UrunAdFoto(1).ToList();
            return View(ufList);
        }
        public ActionResult UrunFotoForm()
        {
            ViewBag.urunSelect = urunSelect();
            return View();
        }

        public ActionResult Save(FileModel uf,HttpPostedFileBase[] files  )
        {
            try
            {
                foreach (HttpPostedFileBase file in files)
                {
                    if(file != null)
                    {
                        string filePath = Path.Combine(Server.MapPath("~/img/urun/"), Guid.NewGuid().ToString() + "_" + file.FileName);
                        file.SaveAs(filePath);
                        string resimAdi = filePath.Split('\\').Last();
                        T_URUN_FOTO urunf = new T_URUN_FOTO();
                        urunf.URUN_ID = uf.URUN_ID;
                        urunf.FOTO = resimAdi;
                        et.T_URUN_FOTO.Add(urunf);
                        et.SaveChanges();
                    }

                }
                
                return RedirectToAction("Index", "UrunFoto");
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "UrunFoto");
            }
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                T_URUN_FOTO search = et.T_URUN_FOTO.Where(q => q.URUN_FOTO_ID == Id).FirstOrDefault();
                if (search != null) 
                {
                    if (search.FOTO != null)
                    {
                        System.IO.File.Delete(Server.MapPath("~/img/urun/"+search.FOTO));
                    }
                    et.T_URUN_FOTO.Remove(search);
                    et.SaveChanges();
                    
                }
                else
                {
                    ;
                }
                return RedirectToAction("Index", "UrunFoto");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
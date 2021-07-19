using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;
using PagedList;
using PagedList.Mvc;

namespace KALEORG.Controllers
{
    public class UrunController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Urun
        public ActionResult Index(int id , int pagesize=9, int page = 1)
        {
            MenuList();
            if (id==0)
            {
                List<T_URUN> urunler = UrunList();
                PagedList<T_URUN> urunModel = new PagedList<T_URUN>(urunler, page, pagesize);
                ViewBag.Id = 0;
                return View(urunModel);
            }
            else
            {
                List<T_URUN> urunler = et.T_URUN.Where(q => q.KAPALI == true && q.KATEGORI_ID == id).ToList();
                PagedList<T_URUN> urunModel = new PagedList<T_URUN>(urunler, page, pagesize);
                ViewBag.Id = id;
                return View(urunModel);
            }
            
        }

        [HttpPost]
        public ActionResult arama(string aranan, int pagesize = 9, int page = 1)
        {
            try
            {
                MenuList();
                List<T_URUN> arananList = et.T_URUN.Where(q => q.KAPALI == true && q.URUN_ADI.Contains(aranan)).ToList();
                PagedList<T_URUN> urunModel = new PagedList<T_URUN>(arananList, page, pagesize);
                return View("Index", urunModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
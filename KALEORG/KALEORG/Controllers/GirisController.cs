using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;
using KALEORG.Controllers;

namespace KALEORG.Controllers
{
    public class GirisController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Giris
        public ActionResult Index()
        {
            MenuList();
            return View();
        }
        public ActionResult Save(string username, string password)
        {
            MenuList();
            try
            {
                T_MUSTERI yeniMusteri = new T_MUSTERI();

            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }

        public ActionResult Kaydol()
        {
            MenuList();
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;
using KALEORG.Controllers;

namespace KALEORG.Controllers
{
    public class HakkimizdaController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            MenuList();
            return View();
        }
    }
}
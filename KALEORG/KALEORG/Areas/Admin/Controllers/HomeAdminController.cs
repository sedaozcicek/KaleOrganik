using KALEORG.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KALEORG.Areas.Admin.Controllers
{
    public class HomeAdminController : SiteBaseController
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            if (getRolesKontrol(1) == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogOut", "LoginAdmin");
            }
            
        }
    }
}
using KALEORG.Controllers;
using KALEORG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KALEORG.Areas.Admin.Controllers
{
    public class MailAdminController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Admin/MailAdmin
        public ActionResult Index()
        {
            MenuList();
            List<T_MAIL> mailList = et.T_MAIL.ToList();
            return View(mailList);
        }

        
    }
}
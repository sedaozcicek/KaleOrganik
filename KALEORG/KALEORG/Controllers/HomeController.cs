using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KALEORG.Models;

namespace KALEORG.Controllers
{
    public class HomeController : SiteBaseController
    {
        KALEORGANICEntities et = new KALEORGANICEntities();
        // GET: Home
        public ActionResult Index()
        {
            
            MenuList();
            ViewBag.randomUrunList = randonUrunList();           
            
            return View();
            
        }
        
            
           
       
    }
}
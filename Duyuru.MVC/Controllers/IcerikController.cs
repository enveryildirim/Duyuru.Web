using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Duyuru.Entities.Models;
namespace Duyuru.MVC.Controllers
{
    public class IcerikController : Controller
    {
        //
        // GET: /Icerik/

        public ActionResult Index()
        {
            return View();
        }
       

        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Icerikler i,HttpPostedFile resim)
        {
            
            return View();
        }

         [HttpPost]
        public ActionResult Guncelle()
        {
            return View();
        }
         [HttpPost]
        public ActionResult Sil()
        {
            return View();
        }


    }
}

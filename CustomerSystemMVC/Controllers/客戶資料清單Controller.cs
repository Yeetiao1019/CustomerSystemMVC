using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerSystemMVC.Models;

namespace CustomerSystemMVC.Controllers
{
    public class 客戶資料清單Controller : Controller
    {
        private Entities db = new Entities();

        // GET: 客戶資料清單
        public ActionResult Index()
        {
            return View(db.客戶View表.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

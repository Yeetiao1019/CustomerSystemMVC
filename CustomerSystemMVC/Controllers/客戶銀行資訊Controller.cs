using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerSystemMVC.Models;
using CustomerSystemMVC.ViewModels;
using Omu.ValueInjecter;

namespace CustomerSystemMVC.Controllers
{
    public class 客戶銀行資訊Controller : Controller
    {
        private Entities db = new Entities();

        // GET: 客戶銀行資訊
        public ActionResult Index()
        {
            var 客戶銀行資訊 = db.客戶銀行資訊.Include(客 => 客.客戶資料);
            return View(客戶銀行資訊.ToList());
        }

        // GET: 客戶銀行資訊/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶銀行資訊/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( 客戶銀行資訊Create 客戶銀行資訊Create)
        {
            客戶銀行資訊 客戶銀行資訊 = new 客戶銀行資訊();
            if (ModelState.IsValid)
            {
                客戶銀行資訊.客戶Id = 客戶銀行資訊Create.客戶Id;
                客戶銀行資訊.銀行名稱 = 客戶銀行資訊Create.銀行名稱;
                客戶銀行資訊.銀行代碼 = 客戶銀行資訊Create.銀行代碼;
                客戶銀行資訊.分行代碼 = 客戶銀行資訊Create.分行代碼;
                客戶銀行資訊.帳戶名稱 = 客戶銀行資訊Create.帳戶名稱;
                客戶銀行資訊.帳戶號碼 = 客戶銀行資訊Create.帳戶號碼;
                
                db.客戶銀行資訊.Add(客戶銀行資訊);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            客戶銀行資訊Edit 客戶銀行資訊Edit = new 客戶銀行資訊Edit();
            客戶銀行資訊Edit.InjectFrom(客戶銀行資訊);

            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶銀行資訊Edit.客戶Id);
            return View(客戶銀行資訊Edit);
        }

        // POST: 客戶銀行資訊/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, 客戶銀行資訊Edit 客戶銀行資訊Edit)
        {
            if (ModelState.IsValid)
            {
                客戶銀行資訊 客戶銀行資訊 =  db.客戶銀行資訊.Find(id);
                客戶銀行資訊.InjectFrom(客戶銀行資訊Edit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶銀行資訊Edit.客戶Id);
            return View(客戶銀行資訊Edit);
        }

        // GET: 客戶銀行資訊/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            db.客戶銀行資訊.Remove(客戶銀行資訊);
            db.SaveChanges();
            return RedirectToAction("Index");
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

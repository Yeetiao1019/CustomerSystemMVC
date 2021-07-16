using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerSystemMVC.Models;
using CustomerSystemMVC.ViewModels;
using Omu.ValueInjecter;

namespace CustomerSystemMVC.Controllers
{
    public class 客戶資料Controller : Controller
    {
        private Entities db = new Entities();

        // GET: 客戶資料
        public ActionResult Index(string searchString)
        {
            var customer =      //定義查詢語法
                from c in db.客戶資料
                where c.刪除 != true
                select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                customer = customer.Where(c => c.客戶名稱.Contains(searchString));
            }

            return View(customer);
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 客戶資料/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(客戶資料Create 客戶資料Create)
        {
            客戶資料 客戶資料 = new 客戶資料();
            if (ModelState.IsValid)
            {
                客戶資料.客戶名稱 = 客戶資料Create.客戶名稱;
                客戶資料.統一編號 = 客戶資料Create.統一編號;
                客戶資料.電話 = 客戶資料Create.電話;
                客戶資料.傳真 = 客戶資料Create.傳真;
                客戶資料.地址 = 客戶資料Create.地址;
                客戶資料.Email = 客戶資料Create.Email;

                db.客戶資料.Add(客戶資料);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eves in ex.EntityValidationErrors)
                    {
                        foreach (var ves in eves.ValidationErrors)
                        {
                            throw new Exception(ves.PropertyName + " : " + ves.ErrorMessage);
                        }
                    }
                }
                return RedirectToAction("Index");
            }

            return View(客戶資料Create);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            客戶資料Edit 客戶資料Edit = new 客戶資料Edit();
            客戶資料Edit.客戶名稱 = 客戶資料.客戶名稱;
            客戶資料Edit.統一編號 = 客戶資料.統一編號;
            客戶資料Edit.電話 = 客戶資料.電話;
            客戶資料Edit.傳真 = 客戶資料.傳真;
            客戶資料Edit.地址 = 客戶資料.地址;
            客戶資料Edit.Email = 客戶資料.Email;

            return View(客戶資料Edit);
        }

        // POST: 客戶資料/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,客戶資料Edit 客戶資料Edit)
        {
            if (ModelState.IsValid)
            {
                客戶資料 客戶資料 = db.客戶資料.Find(id);
                客戶資料.InjectFrom(客戶資料Edit);      //ValueInjector套件，可以幫忙 mapping Model
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eves in ex.EntityValidationErrors)
                    {
                        foreach (var ves in eves.ValidationErrors)
                        {
                            throw new Exception(ves.PropertyName + " : " + ves.ErrorMessage);
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            return View(客戶資料Edit);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料.刪除 = true;
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

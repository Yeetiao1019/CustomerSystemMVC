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
    public class 客戶聯絡人Controller : Controller
    {
        private Entities db = new Entities();

        // GET: 客戶聯絡人
        public ActionResult Index(string searchString, string sort)
        {
            ViewBag.JobTitleSort = sort == "JobTitle" ? "jobTitle_desc" : "JobTitle";
            ViewBag.ContactNameSort = string.IsNullOrEmpty(sort) ? "contactName_desc" : "";
            ViewBag.EmailSort = sort == "Email" ? "email_desc" : "Email";
            ViewBag.CellPhoneSort = sort == "CellPhone" ? "cellPhone_desc" : "CellPhone";
            ViewBag.PhoneSort = sort == "Phone" ? "phone_desc" : "Phone";
            ViewBag.CustomerNameSort = sort =="CustomerName" ? "customerName_desc" : "CustomerName";

            var 客戶聯絡人 = db.客戶聯絡人.Include(客 => 客.客戶資料);

            switch (sort)
            {
                case "jobTitle_desc":
                    客戶聯絡人 = 客戶聯絡人.OrderByDescending(c => c.職稱);
                    break;
                case "JobTitle":
                    客戶聯絡人 = 客戶聯絡人.OrderBy(c => c.職稱);
                    break;
                case "contactName_desc":
                    客戶聯絡人 = 客戶聯絡人.OrderByDescending(c => c.姓名);
                    break;
                case "email_desc":
                    客戶聯絡人 = 客戶聯絡人.OrderByDescending(c => c.Email);
                    break;
                case "Email":
                    客戶聯絡人 = 客戶聯絡人.OrderBy(c => c.Email);
                    break;
                case "cellPhone_desc":
                    客戶聯絡人 = 客戶聯絡人.OrderByDescending(c => c.手機);
                    break;
                case "CellPhone":
                    客戶聯絡人 = 客戶聯絡人.OrderBy(c => c.手機);
                    break;
                case "phone_desc":
                    客戶聯絡人 = 客戶聯絡人.OrderByDescending(c => c.電話);
                    break;
                case "Phone":
                    客戶聯絡人 = 客戶聯絡人.OrderBy(c => c.電話);
                    break;
                case "customerName_desc":
                    客戶聯絡人 = 客戶聯絡人.OrderByDescending(c => c.客戶資料.客戶名稱);
                    break;
                case "CustomerName":
                    客戶聯絡人 = 客戶聯絡人.OrderBy(c => c.客戶資料.客戶名稱);
                    break;
                default:
                    客戶聯絡人 = 客戶聯絡人.OrderBy(c => c.姓名);
                    break;
            }

            var JobTitle =
                (from j in db.客戶聯絡人
                 select new
                 {
                     JobId = j.職稱,
                     JobName = j.職稱
                 }).Distinct().ToList();    //職稱去重複
            List<SelectListItem> JobTitleList = new List<SelectListItem>();

            foreach (var j in JobTitle)
            {
                JobTitleList.Add(new SelectListItem
                {
                    Text = j.JobId,
                    Value = j.JobName
                });
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                客戶聯絡人 = 客戶聯絡人.Where(c => c.職稱 == searchString);
            }

            ViewBag.職稱 = JobTitleList;
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                var customerContact =
                    from c in db.客戶聯絡人
                    where c.客戶Id == 客戶聯絡人.客戶Id
                    select c;
                if (customerContact.Where(
                    e => e.Email == 客戶聯絡人.Email).Count() == 0)
                {
                    db.客戶聯絡人.Add(客戶聯絡人);
                    db.SaveChanges();
                }
                else
                {
                    TempData["ContactAlert"] = "此存在此Email。";
                }

                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                var customerContact =
                  from c in db.客戶聯絡人
                  where c.客戶Id == 客戶聯絡人.客戶Id
                  select c;
                if (customerContact.Where(
                    e => e.Email == 客戶聯絡人.Email).Count() == 0)
                {
                    db.Entry(客戶聯絡人).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    TempData["ContactAlert"] = "此存在此Email。";
                }
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            db.客戶聯絡人.Remove(客戶聯絡人);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehicleRequisitionSystem.Models;

namespace VehicleRequisitionSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UseTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /UseType/
        public ActionResult Index()
        {
            return View(db.UseTypes.ToList());
        }

        // GET: /UseType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UseType usetype = db.UseTypes.Find(id);
            if (usetype == null)
            {
                return HttpNotFound();
            }
            return View(usetype);
        }

        // GET: /UseType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UseType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,TypeName")] UseType usetype)
        {
            if (ModelState.IsValid)
            {
                db.UseTypes.Add(usetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usetype);
        }

        // GET: /UseType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UseType usetype = db.UseTypes.Find(id);
            if (usetype == null)
            {
                return HttpNotFound();
            }
            return View(usetype);
        }

        // POST: /UseType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,TypeName")] UseType usetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usetype);
        }

   
        // POST: /UseType/Delete/5
     
        public ActionResult Delete(int id)
        {
            UseType usetype = db.UseTypes.Find(id);
            db.UseTypes.Remove(usetype);
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

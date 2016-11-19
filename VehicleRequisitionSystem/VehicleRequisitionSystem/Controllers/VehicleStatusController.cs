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
    public class VehicleStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /VehicleStatus/
        public ActionResult Index()
        {
            return View(db.VehicleStatuss.ToList());
        }

        // GET: /VehicleStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleStatus vehiclestatus = db.VehicleStatuss.Find(id);
            if (vehiclestatus == null)
            {
                return HttpNotFound();
            }
            return View(vehiclestatus);
        }

        // GET: /VehicleStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /VehicleStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,StatusName")] VehicleStatus vehiclestatus)
        {
            if (ModelState.IsValid)
            {
                db.VehicleStatuss.Add(vehiclestatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehiclestatus);
        }

        // GET: /VehicleStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleStatus vehiclestatus = db.VehicleStatuss.Find(id);
            if (vehiclestatus == null)
            {
                return HttpNotFound();
            }
            return View(vehiclestatus);
        }

        // POST: /VehicleStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,StatusName")] VehicleStatus vehiclestatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiclestatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehiclestatus);
        }

        // POST: /VehicleStatus/Delete/5
        
        public ActionResult Delete(int id)
        {
            VehicleStatus vehiclestatus = db.VehicleStatuss.Find(id);
            db.VehicleStatuss.Remove(vehiclestatus);
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

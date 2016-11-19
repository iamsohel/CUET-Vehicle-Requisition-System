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
    [Authorize(Roles = "User")]
    public class RequisitionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Requisition/
        public ActionResult Index()
        {
            var requisitions = db.Requisitions.Include(r => r.Department).Include(r => r.Designation).Include(r => r.Driver).Include(r => r.UseType).Include(r => r.Vehicle).Include(r => r.VehicleStatus);
            return View(requisitions.ToList());
        }

        // GET: /Requisition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisitions.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            return View(requisition);
        }

        // GET: /Requisition/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName");
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName");
            ViewBag.UseTypeId = new SelectList(db.UseTypes, "Id", "TypeName");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "VehicleName");
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "DriverName");
            ViewBag.VehicleStatusId = new SelectList(db.VehicleStatuss, "Id", "StatusName");
            return View();
        }

        // POST: /Requisition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsersId,FullName,DepartmentId,DesignationId,VehicleId,WhyUse,UseTypeId,Date,Place,Time,Destination,FileNo,ReturnTime,Mobile,DriverId,VehicleStatusId")] Requisition requisition)
        {
            if (ModelState.IsValid)
            {
                db.Requisitions.Add(requisition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", requisition.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName", requisition.DesignationId);
            ViewBag.UseTypeId = new SelectList(db.UseTypes, "Id", "TypeName", requisition.UseTypeId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "VehicleName", requisition.VehicleId);
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "DriverName", requisition.DriverId);
            ViewBag.VehicleStatusId = new SelectList(db.VehicleStatuss, "Id", "StatusName", requisition.VehicleStatusId);
            return View(requisition);
        }

        // GET: /Requisition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requisition requisition = db.Requisitions.Find(id);
            if (requisition == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", requisition.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName", requisition.DesignationId);
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "DriverName", requisition.DriverId);
            ViewBag.UseTypeId = new SelectList(db.UseTypes, "Id", "TypeName", requisition.UseTypeId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "VehicleName", requisition.VehicleId);
            ViewBag.VehicleStatusId = new SelectList(db.VehicleStatuss, "Id", "StatusName", requisition.VehicleStatusId);
            return View(requisition);
        }

        // POST: /Requisition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,UsersId,FullName,DepartmentId,DesignationId,VehicleId,WhyUse,UseTypeId,Date,Place,Time,Destination,FileNo,ReturnTime,Mobile,DriverId,VehicleStatusId,VehicleNo")] Requisition requisition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requisition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "DepartmentName", requisition.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "Id", "DesignationName", requisition.DesignationId);
            ViewBag.DriverId = new SelectList(db.Drivers, "Id", "DriverName", requisition.DriverId);
            ViewBag.UseTypeId = new SelectList(db.UseTypes, "Id", "TypeName", requisition.UseTypeId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "VehicleName", requisition.VehicleId);
            ViewBag.VehicleStatusId = new SelectList(db.VehicleStatuss, "Id", "StatusName", requisition.VehicleStatusId);
            return View(requisition);
        }

        // POST: /Requisition/Delete/5

        public ActionResult Delete(int id)
        {
            Requisition requisition = db.Requisitions.Find(id);
            db.Requisitions.Remove(requisition);
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

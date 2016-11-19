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
    [Authorize(Roles="Driver")]
    public class DriverReqController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /DriverReq/
        public ActionResult Index()
        {
            var requisitions = db.Requisitions.Include(r => r.Department).Include(r => r.Designation).Include(r => r.Driver).Include(r => r.UseType).Include(r => r.Vehicle).Include(r => r.VehicleStatus);
            return View(requisitions.ToList());
        }

        // GET: /DriverReq/Details/5
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
    
    }
}

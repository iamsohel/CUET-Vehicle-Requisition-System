using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace VehicleRequisitionSystem.Models
{
    public class VehicleContext :DbContext
    {
         public VehicleContext(): base("VehicleContext")
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<UseType> UseTypes { get; set; }
        public DbSet<Requisition> Requisitions { get; set; }
        public DbSet<VehicleStatus> VehicleStatuss { get; set; }
       
    }
}
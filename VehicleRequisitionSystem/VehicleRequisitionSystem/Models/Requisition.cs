using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VehicleRequisitionSystem.Models
{
    public class Requisition
    {
        [Key]
        public int Id { get; set; }

        public string UsersId { get; set; }
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [ForeignKey("Designation")]
        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public string WhyUse { get; set; }
        public int UseTypeId { get; set; }
        public virtual UseType UseType { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public DateTime Time { get; set; }
        public string Destination { get; set; }
        public string FileNo { get; set; }
        public DateTime ReturnTime { get; set; }
        public int Mobile { get; set; }
       
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }

        public int VehicleStatusId { get; set; }
        public virtual VehicleStatus VehicleStatus { get; set; }
        public string VehicleNo { get; set; }
    }
}
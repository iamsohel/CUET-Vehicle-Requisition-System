using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRequisitionSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        public string ShortName { get; set; }
     
    }
}
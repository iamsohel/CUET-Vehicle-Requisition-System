using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using System.Data.Entity;

namespace VehicleRequisitionSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
            
        }
        

        public string Email { get; set; }

        public int Mobile { get; set; }

        public string UsersId { get; set; }
        public string FullName { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("VehicleContext")
        {
        }
       
        public System.Data.Entity.DbSet<VehicleRequisitionSystem.Models.Requisition> Requisitions { get; set; }

        public System.Data.Entity.DbSet<VehicleRequisitionSystem.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<VehicleRequisitionSystem.Models.Designation> Designations { get; set; }

        public System.Data.Entity.DbSet<VehicleRequisitionSystem.Models.UseType> UseTypes { get; set; }

        public System.Data.Entity.DbSet<VehicleRequisitionSystem.Models.Vehicle> Vehicles { get; set; }
        public System.Data.Entity.DbSet<VehicleRequisitionSystem.Models.VehicleStatus> VehicleStatuss { get; set; }

        public System.Data.Entity.DbSet<VehicleRequisitionSystem.Models.Driver> Drivers { get; set; }

        
    }
}
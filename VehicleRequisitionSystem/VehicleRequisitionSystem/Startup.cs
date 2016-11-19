using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VehicleRequisitionSystem.Startup))]
namespace VehicleRequisitionSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

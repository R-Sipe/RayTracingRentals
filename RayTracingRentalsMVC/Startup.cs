using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RayTracingRentalsMVC.Startup))]
namespace RayTracingRentalsMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

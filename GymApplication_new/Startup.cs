using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GymApplication_new.Startup))]
namespace GymApplication_new
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

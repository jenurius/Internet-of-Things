using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IOTWebsite_Final.Startup))]
namespace IOTWebsite_Final
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

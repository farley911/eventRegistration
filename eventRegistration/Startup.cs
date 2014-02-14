using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eventRegistration.Startup))]
namespace eventRegistration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

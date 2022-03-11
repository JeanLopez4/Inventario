using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITory.Startup))]
namespace ITory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

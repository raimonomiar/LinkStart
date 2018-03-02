using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LinkStart.Startup))]
namespace LinkStart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

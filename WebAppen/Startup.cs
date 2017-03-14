using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppen.Startup))]
namespace WebAppen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BaoMing.Startup))]
namespace BaoMing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

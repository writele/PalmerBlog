using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PalmerBlog.Startup))]
namespace PalmerBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

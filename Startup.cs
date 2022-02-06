using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_commerce_Web_Project.Startup))]
namespace E_commerce_Web_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

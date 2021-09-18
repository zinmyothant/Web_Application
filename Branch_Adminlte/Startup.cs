using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Branch_Adminlte.Startup))]
namespace Branch_Adminlte
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PeugeotWorkFlow.Startup))]
namespace PeugeotWorkFlow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

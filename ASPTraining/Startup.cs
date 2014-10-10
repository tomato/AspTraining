using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPTraining.Startup))]
namespace ASPTraining
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApplicantTracker.Startup))]
namespace ApplicantTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

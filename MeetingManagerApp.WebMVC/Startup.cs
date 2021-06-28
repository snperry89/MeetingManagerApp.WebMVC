using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeetingManagerApp.WebMVC.Startup))]
namespace MeetingManagerApp.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRDeneme.Startup))]
namespace SignalRDeneme
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
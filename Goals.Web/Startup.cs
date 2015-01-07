using Goals.Authentication;
using Goals.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace Goals.Web
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			AuthenticationBootstrapper.StartAuthentication(app);
		}
	}
}
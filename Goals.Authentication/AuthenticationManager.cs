using System.Collections.Generic;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Goals.Authentication
{
	public static class AuthenticationManager
	{
		private static IOwinContext OwinContext
		{
			get
			{
				var owinEnvironment = (IDictionary<string, object>) HttpContext.Current.Items["owin.Environment"];
				return new OwinContext(owinEnvironment);
			}
		}

		public static GoalsSignInManager GetSignInManager()
		{
			return OwinContext.Get<GoalsSignInManager>();
		}

		public static GoalsUserManager GetUserManager()
		{
			return OwinContext.Get<GoalsUserManager>();
		}
	}
}
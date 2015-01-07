using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Goals.Authentication
{
	public class GoalsSignInManager : SignInManager<UserProfile, string>
	{
		public GoalsSignInManager(GoalsUserManager userManager, IAuthenticationManager authenticationManager)
			: base(userManager, authenticationManager)
		{
		}

		public override Task<ClaimsIdentity> CreateUserIdentityAsync(UserProfile user)
		{
			return user.GenerateUserIdentityAsync((GoalsUserManager) UserManager);
		}

		public static GoalsSignInManager Create(IdentityFactoryOptions<GoalsSignInManager> options, IOwinContext context)
		{
			return new GoalsSignInManager(context.GetUserManager<GoalsUserManager>(), context.Authentication);
		}
	}
}
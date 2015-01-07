using Microsoft.AspNet.Identity.EntityFramework;

namespace Goals.Authentication
{
	public class GoalsAuthDbContext : IdentityDbContext<UserProfile>
	{
		public GoalsAuthDbContext()
			: base("DefaultConnection", false)
		{
		}

		public static GoalsAuthDbContext Create()
		{
			return new GoalsAuthDbContext();
		}
	}
}
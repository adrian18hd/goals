using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace Goals.Authentication
{
	public class GoalsUserManager : UserManager<UserProfile>
	{
		public GoalsUserManager(IUserStore<UserProfile> store)
			: base(store)
		{
		}

		public static GoalsUserManager Create(IdentityFactoryOptions<GoalsUserManager> options, IOwinContext context)
		{
			var manager = new GoalsUserManager(new UserStore<UserProfile>(context.Get<GoalsAuthDbContext>()));
			// Configure validation logic for usernames
			manager.UserValidator = new UserValidator<UserProfile>(manager)
			{
				AllowOnlyAlphanumericUserNames = false,
				RequireUniqueEmail = true
			};

			// Configure validation logic for passwords
			manager.PasswordValidator = new PasswordValidator
			{
				RequiredLength = 6,
				RequireNonLetterOrDigit = true,
				RequireDigit = true,
				RequireLowercase = true,
				RequireUppercase = true,
			};

			// Configure user lockout defaults
			manager.UserLockoutEnabledByDefault = true;
			manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
			manager.MaxFailedAccessAttemptsBeforeLockout = 5;

			// Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
			// You can write your own provider and plug it in here.
			manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<UserProfile>
			{
				MessageFormat = "Your security code is {0}"
			});
			manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<UserProfile>
			{
				Subject = "Security Code",
				BodyFormat = "Your security code is {0}"
			});
			//manager.EmailService = new EmailService();
			//manager.SmsService = new SmsService();
			IDataProtectionProvider dataProtectionProvider = options.DataProtectionProvider;
			if (dataProtectionProvider != null)
			{
				manager.UserTokenProvider =
					new DataProtectorTokenProvider<UserProfile>(dataProtectionProvider.Create("ASP.NET Identity"));
			}
			return manager;
		}
	}
}
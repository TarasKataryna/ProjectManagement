﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ProjectsManagement.Common
{
	public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole>
	{
		public MyUserClaimsPrincipalFactory(
			UserManager<User> userManager,
			RoleManager<IdentityRole> roleManager,
			IOptions<IdentityOptions> optionsAccessor)
			: base(userManager, roleManager, optionsAccessor)
		{
		}

		protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
		{
			var identity = await base.GenerateClaimsAsync(user);
			identity.AddClaim(new Claim("UserId", user.Id ?? ""));
			return identity;
		}
	}
}

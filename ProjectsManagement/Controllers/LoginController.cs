using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Mappings;
using Common.Models;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ProjectsManagement.Controllers
{
	public class LoginController : Controller
	{
		private SignInManager<User> _signInManager;

		private UserManager<User> _userManager;

		private RoleManager<IdentityRole> _rolesManager;

		public LoginController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_rolesManager = roleManager;
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterModel model)
		{
			IdentityResult result = null;
			if (ModelState.IsValid)
			{
				User user = model.ToUserEntity();
				user.Id = Guid.NewGuid().ToString();

				result = await _userManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(user, "User");

					await _signInManager.SignInAsync(user, false);
					return Ok(true);
				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
			}

			return Ok(result?.Errors);
		}

		[HttpPost]
		public async Task<IActionResult> Login(UserModel model)
		{
			var a = _userManager.FindByNameAsync("tarikkataryna1999@gmail.com").Result;
			if (ModelState.IsValid)
			{
				var result =
					await _signInManager.PasswordSignInAsync(model.Login, model.Password, true, false);
				
				if (result.Succeeded)
				{
					return Ok(true);
				}
				else
				{
					ModelState.AddModelError("", "Неправильный логин и (или) пароль");
				}
			}

			return Ok(ModelState.ValidationState);
		}

		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Login");
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
	}
}

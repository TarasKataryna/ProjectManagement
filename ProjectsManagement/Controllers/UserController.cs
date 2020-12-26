using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces;
using Services.Services;


namespace ProjectsManagement.Controllers
{
	public class UserController : Controller
	{
		private IUserService _userService;

		private UserManager<User> _userManager;

		public UserController(IUserService service, UserManager<User> userManager)
		{
			_userService = service;
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult UsersList()
		{
			var users = _userService.GetUsers().ToList();
			return View(users);
		}

		[HttpGet]
		public IActionResult UserLogs(string userId)
		{
			var logs = _userService.GetLogsByUserId(userId).ToList();
			ViewBag.UserName = _userManager.Users.FirstOrDefault(user => user.Id == userId)?.UserName;

			return View(logs);
		}

	}
}

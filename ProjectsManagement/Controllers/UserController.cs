using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
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

		[HttpGet]
		public IActionResult UserLogsByProject(string userId, int projectPK)
		{
			var logs = _userService.GetLogsByUserIdAndProject(userId, projectPK).ToList();
			ViewBag.UserName = _userManager.Users.FirstOrDefault(user => user.Id == userId)?.UserName;

			return View("UserLogs", logs);
		}

		[HttpGet]
		public IActionResult PartialUserLogs(string userId)
		{
			var logs = _userService.GetLogsByUserId(userId).ToList();

			return PartialView("UserLogs", logs);
		}

		[HttpGet]
		public IActionResult AssignUserToProject(string userPK, int projectPK)
		{
			if (!string.IsNullOrEmpty(userPK?.Trim()) || projectPK != 0)
			{
				var res = _userService.AssignUserToProject(userPK, projectPK);

				return res ? Ok(true) : Ok("Server error");
			}

			return Ok(false);
		}


		[HttpPost]
		public IActionResult LogTime(LogTimeModel model)
		{
			if (ModelState.IsValid)
			{
				var res = _userService.LogTime(model);

				return res ? Ok(true) : Ok("Server error");
			}

			return Ok("Please, fill in all fields");
		}
	}
}

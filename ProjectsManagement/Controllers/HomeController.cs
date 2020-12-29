using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectsManagement.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Common.Mappings;
using Common.Models;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces;

namespace ProjectsManagement.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		private readonly IUserService _userService;

		private readonly UserManager<User> _userManager;

		private IDbContext _context;

		public HomeController(ILogger<HomeController> logger, IUserService userService, UserManager<User> userManager, IDbContext context)
		{
			_logger = logger;
			_userService = userService;
			_userManager = userManager;
			_context = context;
		}

		public IActionResult Index()
		{
			if(User.Identity.IsAuthenticated)
			{
				var userPK = User.Claims
					.First(item => item.Type == ClaimTypes.NameIdentifier).Value.ToString();

				var logs = _userService.GetLogsByUserId(userPK);

				var user = _userManager.Users.FirstOrDefault(u => u.Id == userPK);
				user.Qualification = _context.Qualifications.FirstOrDefault(item => item.QualificationPK == user.QualificationKey);
				user.Position = _context.Positions.FirstOrDefault(item => item.PositionPK == user.PositionKey);


				return View(new UserLogsObjectModel{User = user.ToUserModel(), Logs = logs.ToList()});
			}
			else
			{
				return RedirectToAction("Index", "Login");
			}
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

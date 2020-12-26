using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
using Services.Interfaces;

namespace ProjectsManagement.Controllers
{
	public class ProjectController : Controller
	{
		private IProjectService _projectService;

		public ProjectController(IProjectService service)
		{
			_projectService = service;
		}

		[HttpGet]
		public IActionResult Projects(string userId)
		{
			var result = new List<ProjectModel>();

			if (string.IsNullOrEmpty(userId.Trim()))
			{
				result = _projectService.GetProjectsByUserId(userId).ToList();
			}
			else
			{
				result = _projectService.GetProjects().ToList();
			}

			return View(result);
		}
	}
}

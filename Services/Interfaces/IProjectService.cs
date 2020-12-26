using System;
using System.Collections.Generic;
using System.Text;
using Common.Models;

namespace Services.Interfaces
{
	public interface IProjectService
	{
		IEnumerable<ProjectModel> GetProjects();

		IEnumerable<ProjectModel> GetProjectsByUserId(string userId);
	}
}

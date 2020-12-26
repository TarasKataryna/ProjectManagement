using System;
using System.Collections.Generic;
using System.Text;
using Common.Models;
using DAL.Models;

namespace Common.Mappings
{
	public static class ProjectMapping
	{
		public static Project ToProjectEntity(this ProjectModel model)
		{
			return new Project
			{
				ProjectPK = model.ProjectPK,
				ProjectName = model.ProjectName,
				PlannedDuration = model.PlannedDuration,
				StartDate = model.StartDate
			};
		}

		public static ProjectModel ToProjectModel(this Project entity)
		{
			return new ProjectModel
			{
				ProjectPK = entity.ProjectPK,
				ProjectName = entity.ProjectName,
				PlannedDuration = entity.PlannedDuration,
				StartDate = entity.StartDate
			};
		}
	}
}

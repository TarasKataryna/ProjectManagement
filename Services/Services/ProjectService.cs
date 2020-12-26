using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Models;
using DAL.Data;
using Services.Interfaces;

namespace Services.Services
{
	public class ProjectService : IProjectService
	{
		private IDbContext _context;

		public ProjectService(IDbContext dbContext)
		{
			_context = dbContext;
		}

		public IEnumerable<ProjectModel> GetProjects()
		{
			var res = from p in _context.Projects
					  join o in _context.Orders on p.Order.OrderPK equals o.OrderPK
					  join c in _context.ProjectComplexityTypes on p.ProjectComplexityType.ProjectComplexityTypePK equals c
						  .ProjectComplexityTypePK
					  select new ProjectModel
					  {
						  ProjectPK = p.ProjectPK,
						  ProjectName = p.ProjectName,
						  PlannedDuration = p.PlannedDuration,
						  StartDate = p.StartDate,
						  OrderPK = o.OrderPK,
						  OrderName = o.OrderName,
						  ComplexityTypePK = c.ProjectComplexityTypePK,
						  ProjectComplexityType = c.ProjectComplexityTypeName
					  };

			return res;
		}

		public IEnumerable<ProjectModel> GetProjectsByUserId(string userId)
		{
			var res = from p in _context.Projects
				join o in _context.Orders on p.Order.OrderPK equals o.OrderPK
				join c in _context.ProjectComplexityTypes on p.ProjectComplexityType.ProjectComplexityTypePK equals c
					.ProjectComplexityTypePK
				join pp in _context.ProjectPerformers on p.ProjectPK equals pp.Project.ProjectPK
				join u in _context.Users on userId equals u.Id
				select new ProjectModel
				{
					ProjectPK = p.ProjectPK,
					ProjectName = p.ProjectName,
					PlannedDuration = p.PlannedDuration,
					StartDate = p.StartDate,
					OrderPK = o.OrderPK,
					OrderName = o.OrderName,
					ComplexityTypePK = c.ProjectComplexityTypePK,
					ProjectComplexityType = c.ProjectComplexityTypeName
				};

			return res;
		}
	}
}

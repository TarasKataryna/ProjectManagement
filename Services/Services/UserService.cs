using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Mappings;
using Common.Models;
using DAL.Data;
using DAL.Models;
using Services.Interfaces;

namespace Services.Services
{
	public class UserService : IUserService
	{
		private IDbContext _context;

		public UserService(IDbContext dbContext)
		{
			_context = dbContext;
		}

		public IEnumerable<UserModel> GetUsers() => _context.Users.Select(item => item.ToUserModel());

		public IEnumerable<LogModel> GetLogsByUserId(string id)
		{
			var us = _context.Users.ToList();
			var res = from pp in _context.ProjectPerformers
					  join pph in _context.ProjectPerformerHistories on pp.ProjectPerformerPK equals pph.ProjectPerformer.ProjectPerformerPK
					  join pr in _context.Projects on pp.Project.ProjectPK equals pr.ProjectPK
					  join u in _context.Users on id equals u.Id
					  orderby pr.ProjectName
					  select new LogModel
					  {
						  ProjectPK = pr.ProjectPK,
						  UserPK = u.Id,
						  UserName = u.UserName,
						  ProjectName = pr.ProjectName,
						  SpentHours = pph.SpentHours,
						  WorkDay = pph.WorkDay
					  };

			return res;

		}

		public bool AssignUserToProject(string userPK, int projectPK)
		{
			var user = _context.Users.FirstOrDefault(item => item.Id == userPK);
			var project = _context.Projects.FirstOrDefault(item => item.ProjectPK == projectPK);

			var res = _context.ProjectPerformers.Add(new ProjectPerformer
			{
				Performer = user,
				Project = project
			});

			_context.SaveChanges();

			return res != null;
		}

		public bool LogTime(LogTimeModel model)
		{
			var projectPerfomrer = from pp in _context.ProjectPerformers
								   join p in _context.Projects on model.ProjectPK equals p.ProjectPK
								   join u in _context.Users on model.UserPK equals u.Id
								   where pp.Performer.Id == u.Id && pp.Project.ProjectPK == p.ProjectPK
								   select pp;

			var result = _context.ProjectPerformerHistories.Add(new ProjectPerformerHistory
			{
				ProjectPerformer = projectPerfomrer.First(),
				SpentHours = model.LoggedTime,
				WorkDay = model.Date
			});

			_context.SaveChanges();

			return result != null;
		}

		public IEnumerable<LogModel> GetLogsByUserIdAndProject(string id, int projectPK)
		{
			var res = from pp in _context.ProjectPerformers
					  join pph in _context.ProjectPerformerHistories on pp.ProjectPerformerPK equals pph.ProjectPerformer.ProjectPerformerPK
					  join pr in _context.Projects on pp.Project.ProjectPK equals pr.ProjectPK
					  join u in _context.Users on id equals u.Id
					  where pr.ProjectPK == projectPK
					  orderby pr.ProjectName
					  select new LogModel
					  {
						  ProjectPK = pr.ProjectPK,
						  UserPK = u.Id,
						  UserName = u.UserName,
						  ProjectName = pr.ProjectName,
						  SpentHours = pph.SpentHours,
						  WorkDay = pph.WorkDay
					  };

			return res;
		}
	}
}

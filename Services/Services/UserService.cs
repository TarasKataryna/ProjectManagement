using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Mappings;
using Common.Models;
using DAL.Data;
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
			var res = from pp in _context.ProjectPerformers
					  join pph in _context.ProjectPerformerHistories on pp.ProjectPerformerPK equals pph
						  .ProjectPerformerHistoryPK
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
	}
}

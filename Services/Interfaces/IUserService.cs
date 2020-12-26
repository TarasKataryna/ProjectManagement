﻿using System;
using System.Collections.Generic;
using System.Text;
using Common.Models;
using DAL.Data;
using DAL.Models;

using Microsoft.AspNetCore.Identity;

namespace Services.Interfaces
{
	public interface IUserService
	{
		IEnumerable<UserModel> GetUsers();

		IEnumerable<LogModel> GetLogsByUserId(string id);
	}
}

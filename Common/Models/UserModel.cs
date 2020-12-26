using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
	public class UserModel
	{
		public string Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string IsAdmin { get; set; }
	}
}

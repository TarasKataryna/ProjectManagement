using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
	public class User : IdentityUser
	{
		[Required]
		public string Login { get; set; }

		public string FirstName { get; set; }
		
		public string LastName { get; set; }
		public string IsAdmin { get; set; }
	}
}

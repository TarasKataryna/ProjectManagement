using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
	public class RegisterModel
	{
		[Required]
		public string Login { get; set; }
		
		[Required]
		public string Password { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }
	}
}

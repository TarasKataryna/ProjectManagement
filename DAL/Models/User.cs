using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

		public int? QualificationKey { get; set; }

		[ForeignKey("QualificationKey")]
		public Qualification? Qualification { get; set; }

		public int? PositionKey { get; set; }

		[ForeignKey("PositionKey")]
		public Position? Position { get; set; }
	}
}

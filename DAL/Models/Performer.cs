using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
	public class Performer: User
	{
		public Position Position  { get; set; }

		public Qualification Qualification{ get; set; }
	}
}

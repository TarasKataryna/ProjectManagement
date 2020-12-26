using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
	public class Position
	{
		[Key]
		public int PositionPK { get; set; }

		public string PositionName { get; set; }

		public double HourlyPremium { get; set; }
	}
}

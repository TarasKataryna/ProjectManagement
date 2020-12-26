using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
	public class Qualification
	{
		[Key]
		public int QualificationPK { get; set; }

		public string QualificationName { get; set; }

		public double HourlyRate { get; set; }
	}
}

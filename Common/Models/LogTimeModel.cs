using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
	public class LogTimeModel
	{
		[Required]
		public string UserPK { get; set; }

		[Required]
		public int ProjectPK { get; set; }

		[Required]
		public DateTime Date { get; set; }

		[Required]
		public double LoggedTime { get; set; }
	}
}

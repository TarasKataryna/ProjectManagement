using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
	public class LogModel
	{
		public string UserPK { get; set; }

		public int ProjectPK { get; set; }

		public string UserName { get; set; }

		public string ProjectName { get; set; }

		public DateTime WorkDay { get; set; }

		public double SpentHours { get; set; }


	}
}

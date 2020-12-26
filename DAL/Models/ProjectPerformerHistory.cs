using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
	public class ProjectPerformerHistory
	{
		[Key]
		public int ProjectPerformerHistoryPK { get; set; }

		public ProjectPerformer ProjectPerformer { get; set; }

		public DateTime WorkDay { get; set; }

		public double SpentHours { get; set; }
	}
}

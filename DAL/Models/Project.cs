using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
	public class Project
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProjectPK { get; set; }

		public string ProjectName { get; set; }

		public int PlannedDuration { get; set; }

		public DateTime StartDate { get; set; }

		public Order Order { get; set; }

		public ProjectComplexityType ProjectComplexityType { get; set; }
	}
}

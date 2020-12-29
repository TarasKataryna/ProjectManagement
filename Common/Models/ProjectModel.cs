using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
	public class ProjectModel
	{
		public int ProjectPK { get; set; }

		[Required]
		public string ProjectName { get; set; }

		[Required]
		public int PlannedDuration { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		public string OrderName { get; set; }

		public int OrderPK { get; set; }

		public string ProjectComplexityType { get; set; }

		public int ComplexityTypePK{ get; set; }
}
}

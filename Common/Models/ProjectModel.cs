using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
	public class ProjectModel
	{
		public int ProjectPK { get; set; }

		public string ProjectName { get; set; }

		public int PlannedDuration { get; set; }

		public DateTime StartDate { get; set; }

		public string OrderName { get; set; }

		public int OrderPK { get; set; }

		public string ProjectComplexityType { get; set; }

		public int ComplexityTypePK{ get; set; }
}
}

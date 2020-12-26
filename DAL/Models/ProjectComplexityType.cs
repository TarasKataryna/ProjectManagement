using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
	public class ProjectComplexityType
	{
		[Key]
		public int ProjectComplexityTypePK { get; set; }

		public string ProjectComplexityTypeName { get; set; }
	}
}

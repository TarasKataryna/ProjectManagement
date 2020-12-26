using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
	public class ProjectPerformer
	{
		[Key]
		public int ProjectPerformerPK { get; set; }

		public User Performer { get; set; }

		public Project Project { get; set; }
	}
}

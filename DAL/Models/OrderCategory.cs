using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
	public class OrderCategory
	{
		[Key]
		public int OrderCategoryPK { get; set; }

		public string OrderCategoryName { get; set; }
	}
}

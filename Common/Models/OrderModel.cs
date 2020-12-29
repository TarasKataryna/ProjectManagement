using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
	public class OrderModel
	{
		public int OrderPK { get; set; }

		[Required]
		public string OrderName { get; set; }

		public int CustomerPK { get; set; }

		public string CustomerName { get; set; }

		public int CategoryTypePK { get; set; }

		public string CategoryType { get; set; }

		public double InitialOrderCost { get; set; }

		public double MonthlyCost { get; set; }

	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderPK { get; set; }

		public string OrderName { get; set; }

		public Customer Customer { get; set; }

		public double InitialOrderCost { get; set; }

		public double MonthlyCost { get; set; }

		public OrderCategory Category { get; set; }
	}
}

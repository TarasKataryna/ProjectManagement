using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
	public class Customer
	{
		[Key]
		public int CustomerPK { get; set; }

		public string CustomerName { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Models
{
	public class OrderPayment
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderPaymentPK { get; set; }

		public double PaymentSum { get; set; }

		public DateTime DateAdded { get; set; }

		public Order Order { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Common.Models
{
	public class CustomerModel
	{
		public int CustomerPK { get; set; }

		[Required]
		public string CustomerName { get; set; }
	}
}

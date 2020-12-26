using System;
using System.Collections.Generic;
using System.Text;
using Common.Models;

namespace Services.Interfaces
{
	public interface IOrderService
	{
		IEnumerable<OrderModel> GetOrders();

		IEnumerable<CustomerModel> GetCustomers();
	}
}

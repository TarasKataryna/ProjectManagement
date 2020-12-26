using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Services.Interfaces
{
	public interface IOrderService
	{
		IEnumerable<OrderModel> GetOrders();

		bool CreateOrder(OrderModel model);

		IEnumerable<CustomerModel> GetCustomers();

		Task<bool> CreateCustomer(CustomerModel model);
	}
}

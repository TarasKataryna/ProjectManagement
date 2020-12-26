using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Models;
using DAL.Data;
using Services.Interfaces;

namespace Services.Services
{
	public class OrderService : IOrderService
	{
		private IDbContext _context;

		public OrderService(IDbContext dbContext)
		{
			_context = dbContext;
		}

		public IEnumerable<OrderModel> GetOrders()
		{
			var res = from o in _context.Orders
				join c in _context.Customers on o.Customer.CustomerPK equals c.CustomerPK
				join cat in _context.OrderCategories on o.Category.OrderCategoryPK equals cat.OrderCategoryPK
				orderby o.OrderName
				select new OrderModel
				{
					OrderPK = o.OrderPK,
					OrderName = o.OrderName,
					CustomerPK = c.CustomerPK,
					CustomerName = c.CustomerName,
					CategoryTypePK = cat.OrderCategoryPK,
					CategoryType = cat.OrderCategoryName,
					InitialOrderCost = o.InitialOrderCost,
					MonthlyCost = o.MonthlyCost
				};

			return res;
		}

		public IEnumerable<CustomerModel> GetCustomers()
		{
			var res = _context.Customers.Select(item => new CustomerModel
			{
				CustomerPK = item.CustomerPK,
				CustomerName = item.CustomerName
			});

			return res;
		}

		
	}
}

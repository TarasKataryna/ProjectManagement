using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using DAL.Data;
using DAL.Models;
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

		public bool CreateOrder(OrderModel model)
		{
			var orderCategory = _context.OrderCategories.FirstOrDefault(item => item.OrderCategoryPK == model.CategoryTypePK);
			var customer = _context.Customers.FirstOrDefault(item => item.CustomerPK == model.CustomerPK);

			var order = new Order
			{
				OrderName = model.OrderName,
				Category = orderCategory,
				Customer = customer,
				InitialOrderCost = model.InitialOrderCost,
				MonthlyCost = model.MonthlyCost
			};

			var result = _context.Orders.Add(order);

			_context.SaveChanges();

			return result != null;
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

		public async Task<bool> CreateCustomer(CustomerModel model)
		{
			var customer = new Customer
			{
				CustomerName = model.CustomerName
			};

			var result = await _context.Customers.AddAsync(customer);

			_context.SaveChanges();

			return result != null;
		}

		public IEnumerable<CategoryModel> GetCategories()
		{
			return _context.OrderCategories.Select(item => new CategoryModel
			{
				OrderCategoryPK = item.OrderCategoryPK,
				OrderCategoryName = item.OrderCategoryName
			});
		}
	}
}

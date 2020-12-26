using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Services.Interfaces;

namespace ProjectsManagement.Controllers
{
	public class OrderController : Controller
	{
		private IOrderService _orderService;

		public OrderController(IOrderService service)
		{
			_orderService = service;
		}

		[HttpGet]
		public IActionResult Orders()
		{
			var res = _orderService.GetOrders().ToList();
			return View(res);
		}

		[HttpGet]
		public IActionResult Customers()
		{
			var res = _orderService.GetCustomers().ToList();
			return View(res);
		}

		[HttpPost]
		public IActionResult CreateCustomer(Customer customer)
		{

		}
	}
}

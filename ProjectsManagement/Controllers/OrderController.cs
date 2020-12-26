using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models;
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

		[HttpPost]
		public IActionResult CreateOrder(OrderModel model)
		{
			if (ModelState.IsValid)
			{
				var res = _orderService.CreateOrder(model);
				return res ? Ok(true) : Ok("Server error");
			}

			return Ok("Please, fill in all field.");
		}

		[HttpGet]
		public IActionResult Customers()
		{
			var res = _orderService.GetCustomers().ToList();
			return View(res);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCustomer(CustomerModel customer)
		{
			if (ModelState.IsValid)
			{
				var res = await _orderService.CreateCustomer(customer);
				return res ? Ok(true) : Ok("Server error");
			}

			return Ok("Please, fill in Customer Name field.");

		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
	public interface IDbContext
	{
		 DbSet<Customer> Customers { get; set; }
		 DbSet<Order> Orders { get; set; }
		 DbSet<OrderCategory> OrderCategories { get; set; }
		 DbSet<OrderPayment> OrderPayments { get; set; }
		 DbSet<Performer> Performers { get; set; }
		 DbSet<Position> Positions { get; set; }
		 DbSet<Project> Projects { get; set; }
		 DbSet<ProjectComplexityType> ProjectComplexityTypes { get; set; }
		 DbSet<ProjectPerformer> ProjectPerformers { get; set; }
		 DbSet<ProjectPerformerHistory> ProjectPerformerHistories { get; set; }
		 DbSet<Qualification> Qualifications { get; set; }
		 DbSet<User> Users{ get; set; }
	}
}

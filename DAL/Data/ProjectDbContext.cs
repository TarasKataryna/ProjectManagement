using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
	public sealed class ProjectDbContext : IdentityDbContext<User>, IDbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderCategory> OrderCategories { get; set; }
		public DbSet<OrderPayment> OrderPayments { get; set; }
		public DbSet<Performer> Performers { get; set; }
		public DbSet<Position> Positions { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<ProjectComplexityType> ProjectComplexityTypes { get; set; }
		public DbSet<ProjectPerformer> ProjectPerformers { get; set; }
		public DbSet<ProjectPerformerHistory> ProjectPerformerHistories { get; set; }
		public DbSet<Qualification> Qualifications { get; set; }
		public DbSet<User> Users { get; set; }


		public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
		{
			//Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var adminRoleId = Guid.NewGuid();
			modelBuilder.Entity<IdentityRole>().HasData(new List<IdentityRole>
			{
				new IdentityRole
				{
					Id = adminRoleId.ToString(),
					Name = "Admin",
					NormalizedName = "Admin".ToUpper()
				},
				new IdentityRole
				{
					Name = "User",
					NormalizedName = "User".ToUpper()
				}
			});

			modelBuilder.Entity<OrderCategory>().HasData(new List<OrderCategory>()
			{
				new OrderCategory
				{
					OrderCategoryPK = 1,
					OrderCategoryName = "First Category"
				},
				new OrderCategory
				{
					OrderCategoryPK = 2,
					OrderCategoryName = "Second Category"
				},
				new OrderCategory
				{
					OrderCategoryPK = 3,
					OrderCategoryName = "Third Category"
				}
			});

			var userId = Guid.NewGuid();
			var user = new User
			{
				Id = userId.ToString(),
				UserName = "tarikkataryna1999@gmail.com",
				NormalizedUserName = "tarikkataryna1999@gmail.com".ToUpper(),
				Email = "tarikkataryna1999@gmail.com",
				Login = "tarikkataryna1999@gmail.com",
				FirstName = "Taras",
				LastName = "Kataryna",
				PasswordHash = (new PasswordHasher<User>()).HashPassword(null, "12345")
			};

			modelBuilder.Entity<IdentityUserRole<string>>().HasData(new List<IdentityUserRole<string>>
			{
				new IdentityUserRole<string>
				{
					UserId = userId.ToString(),
					RoleId = adminRoleId.ToString()
				}
			});
		}
	}
}

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

			var adminRoleId = "1ba68bf3-7f4c-45a6-ab5b-7e9be54e3e47";
			modelBuilder.Entity<IdentityRole>().HasData(new List<IdentityRole>
			{
				new IdentityRole
				{
					Id = adminRoleId,
					Name = "Admin",
					NormalizedName = "Admin".ToUpper(),
					ConcurrencyStamp = "fdd41c7d-4879-42d3-a5eb-dc2f28921cd6"
				},
				new IdentityRole
				{
					Id = "2a7f0297-c806-4192-95a4-f3be699c4420",
					Name = "User",
					NormalizedName = "User".ToUpper(),
					ConcurrencyStamp = "c066d625-dcfc-4e03-a036-045f336c0dae"
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

			var userId = "e7c5d9a6-2584-4ace-86df-559a8480f978";
			var user = new User
			{
				Id = userId,
				UserName = "tarikkataryna1999@gmail.com",
				NormalizedUserName = "tarikkataryna1999@gmail.com".ToUpper(),
				Email = "tarikkataryna1999@gmail.com",
				Login = "tarikkataryna1999@gmail.com",
				FirstName = "Taras",
				LastName = "Kataryna",
				PasswordHash = (new PasswordHasher<User>()).HashPassword(null, "12345")
			};

			modelBuilder.Entity<User>().HasData(new List<User> { user });

			modelBuilder.Entity<IdentityUserRole<string>>().HasData(new List<IdentityUserRole<string>>
			{
				new IdentityUserRole<string>
				{
					UserId = userId,
					RoleId = adminRoleId
				}
			});

			modelBuilder.Entity<ProjectComplexityType>().HasData(new List<ProjectComplexityType>
			{
				new ProjectComplexityType
				{
					ProjectComplexityTypePK = 1,
					ProjectComplexityTypeName = "Easy"
				},
				new ProjectComplexityType
				{
					ProjectComplexityTypePK = 2,
					ProjectComplexityTypeName = "Medium"
				},
				new ProjectComplexityType
				{
					ProjectComplexityTypePK = 3,
					ProjectComplexityTypeName = "Hard"
				}
			});

			modelBuilder.Entity<Qualification>().HasData(new List<Qualification>
			{
				new Qualification
				{
					QualificationPK = 1,
					QualificationName = "First Qualification",
					HourlyRate = 5
				},
				new Qualification
				{
					QualificationPK = 2,
					QualificationName = "Second Qualification",
					HourlyRate = 7
				},
				new Qualification
				{
					QualificationPK = 3,
					QualificationName = "Third Qualification",
					HourlyRate = 10
				}
			});

			modelBuilder.Entity<Position>().HasData(new List<Position>
			{
				new Position
				{
					PositionPK = 1,
					PositionName = "Junior",
					HourlyPremium = 1
				},
				new Position
				{
					PositionPK = 2,
					PositionName = "Medium",
					HourlyPremium = 2
				},
				new Position
				{
					PositionPK = 3,
					PositionName = "Senior",
					HourlyPremium = 3
				}
			});

		}

		public new int SaveChanges()
		{
			return base.SaveChanges();
		}
	}
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Common;
using Services.Interfaces;
using Services.Services;

namespace ProjectsManagement
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ProjectDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

			services.AddIdentity<User, IdentityRole>(options =>
			{
				options.Password.RequireUppercase = false;
				options.Password.RequireDigit = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequiredLength = 5;
				options.Password.RequireLowercase = false;

				options.User.RequireUniqueEmail = true;

			}).AddEntityFrameworkStores<ProjectDbContext>();

			services.AddScoped<IDbContext, ProjectDbContext>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IProjectService, ProjectService>();
			services.AddScoped<IOrderService, OrderService>();

			services.AddScoped<IUserClaimsPrincipalFactory<User>, MyUserClaimsPrincipalFactory>();

			services.AddControllersWithViews().AddRazorRuntimeCompilation();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
			{
				if (serviceScope != null)
				{
					var context = serviceScope.ServiceProvider.GetRequiredService<ProjectDbContext>();
					context.Database.EnsureCreated();
				}
			}

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}

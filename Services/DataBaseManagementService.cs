using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace ubc.Services
{
	public static class DataBaseManagementService
	{
		public static void MigrationInitialization(this IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{
				var serviceDb = serviceScope.ServiceProvider.GetService<Models.AppDbContext>();

				serviceDb.Database.Migrate();
			}
		}
	}
}


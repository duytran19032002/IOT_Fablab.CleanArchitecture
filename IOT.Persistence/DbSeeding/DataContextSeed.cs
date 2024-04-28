using IOT.Domain;
using IOT.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Persistence.DbSeeding;

public static class DataContextSeed
{
	public static IHost SeedCustomer(this IHost host)
	{
		using var scope = host.Services.CreateScope();
		var customerContext = scope.ServiceProvider
			.GetRequiredService<IOTDbContext>();
		customerContext.Database.MigrateAsync().GetAwaiter().GetResult();

		CreateCustomer(customerContext, "area1", "area1")
			.GetAwaiter()
			.GetResult();

		CreateCustomer(customerContext, "area2", "area2")
			.GetAwaiter()
			.GetResult();

		return host;
	}

	private static async Task CreateCustomer(IOTDbContext dataContext, string name, string value)
	{
		var data = await dataContext.Areas
			.SingleOrDefaultAsync(x => x.AreaId.Equals(name) || x.Description.Equals(value));

		if (data == null)
		{
			var newData = new Area
			{
				AreaId = name,
				Description = value

			};

			await dataContext.Areas.AddAsync(newData);
			await dataContext.SaveChangesAsync();
		}
	}
}

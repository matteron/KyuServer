using System.Collections.Generic;
using KyuApi.Business.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace KyuApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureHostConfiguration(config =>
				{
					var options = new Dictionary<string, string>
					{
						{ "JwtOptions:Secret", JwtHelper.GenerateSecret() }
					};
					config.AddInMemoryCollection(options);
				})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}

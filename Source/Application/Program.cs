using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Hosting;

namespace Application
{
	public class Program
	{
		#region Methods

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			return Host.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration(configurationBuilder =>
				{
					foreach(var configurationSource in configurationBuilder.Sources)
					{
						if(!(configurationSource is JsonConfigurationSource jsonConfigurationSource))
							continue;

						// To get it working in a Linux container where file-names are case-sensitive.
						jsonConfigurationSource.Path = jsonConfigurationSource.Path.Replace("appsettings", "AppSettings", StringComparison.OrdinalIgnoreCase);
					}
				})
				.ConfigureWebHostDefaults(webHostBuilder => { webHostBuilder.UseStartup<Startup>(); });
		}

		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		#endregion
	}
}
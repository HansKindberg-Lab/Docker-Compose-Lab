using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Application.Controllers
{
	public class HomeController : Controller
	{
		#region Constructors

		public HomeController(IConfiguration configuration)
		{
			this.Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
		}

		#endregion

		#region Properties

		protected internal virtual IConfiguration Configuration { get; }

		#endregion

		#region Methods

		public virtual async Task<IActionResult> ConfigurationJson()
		{
			var jsonObject = new JObject();

			this.PopulateJsonObject(this.Configuration, jsonObject);

			return this.Content(await this.ToJsonAsync(jsonObject));
		}

		public virtual async Task<IActionResult> ConfigurationProviders()
		{
			var jsonObject = new JObject();

			// ReSharper disable InvertIf
			if(this.Configuration is IConfigurationRoot configurationRoot)
			{
				for(var i = 0; i < configurationRoot.Providers.Count(); i++)
				{
					var provider = configurationRoot.Providers.ElementAt(i);

					var information = provider.GetType().FullName;

					if(provider is FileConfigurationProvider fileConfigurationProvider)
						information += " (" + fileConfigurationProvider.Source.Path + ")";

					jsonObject.Add(i.ToString(CultureInfo.InvariantCulture), information);
				}
			}
			// ReSharper restore InvertIf

			return this.Content(await this.ToJsonAsync(jsonObject));
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public virtual async Task<IActionResult> Error()
		{
			return await Task.FromResult(this.View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier}));
		}

		public virtual async Task<IActionResult> Index()
		{
			return await Task.FromResult(this.View());
		}

		protected internal virtual void PopulateJsonObject(IConfiguration configuration, JObject jsonObject)
		{
			if(configuration == null)
				throw new ArgumentNullException(nameof(configuration));

			if(jsonObject == null)
				throw new ArgumentNullException(nameof(jsonObject));

			foreach(var child in configuration.GetChildren().OrderBy(child => child.Key))
			{
				if(child.Exists())
				{
					if(child.Value != null)
					{
						jsonObject.Add(child.Key, new JValue(child.Value));
					}
					else
					{
						var childJsonObject = new JObject();
						this.PopulateJsonObject(child, childJsonObject);
						jsonObject.Add(child.Key, childJsonObject);
					}
				}
				else
				{
					jsonObject.Add(child.Key, null);
				}
			}
		}

		public virtual async Task<IActionResult> Privacy()
		{
			return await Task.FromResult(this.View());
		}

		[SuppressMessage("Style", "IDE0063:Use simple 'using' statement")]
		protected internal virtual async Task<string> ToJsonAsync(JObject jsonObject)
		{
			// ReSharper disable ConvertToUsingDeclaration
			await using(var stringWriter = new StringWriter())
			{
				using(var jsonTextWriter = new JsonTextWriter(stringWriter) {Formatting = Formatting.Indented, Indentation = 1, IndentChar = '\t'})
				{
					new JsonSerializer().Serialize(jsonTextWriter, jsonObject);

					return stringWriter.ToString();
				}
			}
			// ReSharper restore ConvertToUsingDeclaration
		}

		#endregion
	}
}
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using GrowEasy.Repository;
using GrowEasy.Repository.Interfaces;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace GrowEasy
	{
	public class Startup
		{
		public Startup(IConfiguration configuration)
			{
			this.Configuration = configuration;

			}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
			{
			services.AddControllers();

			services.AddDbContext<RContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddMvc().AddXmlSerializerFormatters();
			services.AddDbContext<RContext>(opt =>
				opt.UseInMemoryDatabase(databaseName: "MainDescInMemory")
				.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

			services.AddScoped<IMainDesc, ReposMainDesc>();
			services.AddScoped<IVivencia, ReposVivencia>();
			services.AddScoped<IActivitie, ReposACtion>();

			services.AddDbContext<RContext>(options =>	{
				options.ConfigureWarnings(warnings =>
				warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
			});

			/* JSON */

			services.AddMvc()
				.AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
						

			}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
			{
			var enUS = new CultureInfo("en-US");
			var localizationOptions = new RequestLocalizationOptions
				{
				DefaultRequestCulture = new RequestCulture(enUS),
				SupportedCultures = new List<CultureInfo> { enUS },
				SupportedUICultures = new List<CultureInfo> { enUS }
				};

			app.UseRequestLocalization(localizationOptions);

			if (env.IsDevelopment())
				{
				app.UseDeveloperExceptionPage();
				}
			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
			}
		}
	}

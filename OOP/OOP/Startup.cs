using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OOP.DAL;
using OOP.DAL.Interface;
using OOP.DAL.Repositories;
using OOP.Domain.Entity;
using OOP.Service.Interfaces;
using NLog.Extensions.Logging;
using OOP.Service.Implementations;


namespace OOP
{
	public class Startup
	{
		private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = _configuration.GetConnectionString("MyDbConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
                ServiceLifetime.Scoped);

            // Dependency injection
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IBaseRepository<Client>, ClientRepository>();

            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.SetMinimumLevel(LogLevel.Trace);
            });

            // NLog configuration
            NLog.LogManager.LoadConfiguration("nlog.config");

            // Создайте объект loggerFactory и добавьте его в коллекцию служб
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddNLog();
            });
            services.AddSingleton(loggerFactory);

            // MVC configuration
            services.AddControllersWithViews();

            // Authentication configuration
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Login");
                });

            // Custom services initialization
            services.InitializeRepositories();
            services.InitializeServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Account}/{action=Register}/{id?}");
			});
		}
	}
}

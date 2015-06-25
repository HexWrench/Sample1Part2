using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Data.Entity;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Sample1Data;

namespace Sample1
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            Configuration = new Configuration()
                .AddJsonFile("Config.json")
                .AddEnvironmentVariables();
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var connectionString = Configuration.Get("Data:DefaultConnection:ConnectionString");

            // Register Entity Framework
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<AspNetDataContext>(options =>
                {
                    Console.Write(connectionString);
                      options.UseSqlServer(connectionString);
                });

            services.AddScoped<IDataContext, AspNetDataContext>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();

            var playerService = ActivatorUtilities.CreateInstance<PlayerService>(app.ApplicationServices);
            playerService.InititalizeData();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}

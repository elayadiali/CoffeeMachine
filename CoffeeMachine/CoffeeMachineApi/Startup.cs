using CoffeeApiMachine.Interfaces;
using CoffeeApiMachine.Services;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoffeeApiMachine
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });


            services.AddControllers();

            services.AddDbContext<CoffeeDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CoffeeDbContext")));

            services.AddTransient<ITypeDrinkService, TypeDrinkService>();
            services.AddTransient<IBadgeService, BadgeService>();
            services.AddTransient<IClientChoiceService, ClientChoiceService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

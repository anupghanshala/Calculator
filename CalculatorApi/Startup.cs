using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculate.Repository.Context;
using Calculate.Repository.Interface.Interface;
using Calculate.Repository.Repository;
using Calculate.Service.Interface.Interface;
using Calculate.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CalculatorApi
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
            services.AddControllers();
            services.AddTransient<ILogCalculationService, LogCalculationService>();
            services.AddTransient<ILogCalculationRepository, LogCalculationRepository > ();
            services.AddTransient<ICalculateService, CalculateService>();
            services.AddDbContext<CalculateDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                                            sqlOptions => sqlOptions.CommandTimeout(300)
                                                                                    .MigrationsAssembly("CalculatorApi")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelOrder.Core.IRepositories;
using HotelOrder.Core.IServices;
using HotelOrder.Models;
using HotelOrder.Repositories;
using HotelOrder.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace HotelOrder
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
            var info = new OpenApiInfo()
            {
                Version = "v1",
                Title = "Swagger Hotel Order API",
                Description = "Swagger Hotel Order API Description",
                TermsOfService = new Uri("http://www.urtechapps.com"),
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", info);
            });

            services.AddScoped<IDiningService, DiningService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITrackingService, TrackingService>();
            services.AddScoped<ITrackingRepository, TrackingRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IDiningRepository, DiningRepository>();
            services.AddDbContext<HotelOrderDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("HotelContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                "Swagger Hotel Order API v1");
            });
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

using DotNetEngineerAssignment.Application.BusinessContexts;
using DotNetEngineerAssignment.Application.SeedWork;
using DotNetEngineerAssignment.Application.Services.Concretes;
using DotNetEngineerAssignment.Application.Services.Contracts;
using DotNetEngineerAssignment.Core.Domain.Repository;
using DotNetEngineerAssignment.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DotNetEngineerAssignment
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
            services.AddDbContext<OrderDbContext>(option =>
            option.UseInMemoryDatabase("TestDB"), ServiceLifetime.Transient);

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductTypeStrategyService, ProductTypeStrategyService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ISeedDatabaseService, SeedDatabaseService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotNetEngineerAssignment", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNetEngineerAssignment v1");
                    c.DefaultModelsExpandDepth(-1);
                });
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

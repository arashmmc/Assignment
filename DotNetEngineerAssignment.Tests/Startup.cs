using DotNetEngineerAssignment.Application.BusinessContexts;
using DotNetEngineerAssignment.Application.SeedWork;
using DotNetEngineerAssignment.Application.Services.Concretes;
using DotNetEngineerAssignment.Application.Services.Contracts;
using DotNetEngineerAssignment.Core.Domain.Repository;
using DotNetEngineerAssignment.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.DependencyInjection;


namespace DotNetEngineerAssignment.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OrderDbContext>(option => option.UseInMemoryDatabase("TestDB"), ServiceLifetime.Transient);
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductTypeStrategyService, ProductTypeStrategyService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ISeedDatabaseService, SeedDatabaseService>();
        }
    }
}



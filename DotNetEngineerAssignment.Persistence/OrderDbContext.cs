using DotNetEngineerAssignment.Core.Domain.Entity;
using DotNetEngineerAssignment.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DotNetEngineerAssignment.Persistence
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        { }

        public DbSet<OrderInformation> OrderInformations { get; set; }
        public DbSet<OrderItemInfo> OrderItemInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(OrderInformationEntityTypeConfiguration.GetNew());
            base.OnModelCreating(modelBuilder);
        }
    }
}

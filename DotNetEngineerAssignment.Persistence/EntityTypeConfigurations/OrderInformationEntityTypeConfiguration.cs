using DotNetEngineerAssignment.Core.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetEngineerAssignment.Persistence.EntityTypeConfigurations
{
    public class OrderInformationEntityTypeConfiguration : IEntityTypeConfiguration<OrderInformation>
    {
        public static OrderInformationEntityTypeConfiguration GetNew() => new();

        public void Configure(EntityTypeBuilder<OrderInformation> builder)
        {
            builder.HasKey(i => i.OrderId);
            builder.Property(i => i.OrderId).ValueGeneratedOnAdd();
            builder.Property(i => i.RequiredBinWidth);
            builder.HasMany(i => i.Items).WithOne().HasForeignKey(i => i.OrderId);
        }

    }
}

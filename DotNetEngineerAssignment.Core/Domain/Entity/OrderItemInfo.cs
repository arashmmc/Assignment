
using DotNetEngineerAssignment.Domain.Eums;

namespace DotNetEngineerAssignment.Core.Domain.Entity
{
    public class OrderItemInfo
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public ProductType ProductType { get; set; }
        public int Quantity { get; set; }
        
    }
}

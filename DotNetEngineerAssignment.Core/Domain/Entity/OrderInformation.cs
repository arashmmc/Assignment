using System.Collections.Generic;

namespace DotNetEngineerAssignment.Core.Domain.Entity
{
    public class OrderInformation
    {
        public long OrderId { get; set; }
        public virtual List<OrderItemInfo> Items { get; set; }
        public decimal RequiredBinWidth { get; set; }
    }
}

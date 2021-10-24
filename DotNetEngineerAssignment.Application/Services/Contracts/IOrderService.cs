using DotNetEngineerAssignment.Core.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetEngineerAssignment.Application.Services.Contracts
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderInformation>> GetAllAsync();
        Task<OrderInformation> GetByIdAsync(long id);
        Task<RequiredBinWidth> CreateAsync(OrderInformation order);
        Task UpdateAsync(OrderInformation order);
        Task UpdateOrderItemInfoAsync(OrderItemInfo orderItemInfo);
        Task DeleteAsync(long id);
    }
}

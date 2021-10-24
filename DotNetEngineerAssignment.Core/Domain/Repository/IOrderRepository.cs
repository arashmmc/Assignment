using DotNetEngineerAssignment.Core.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetEngineerAssignment.Core.Domain.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderInformation>> GetAllAsync();
        Task<OrderInformation> GetByIdAsync(long id);
        Task CreateAsync(OrderInformation order);
        Task AddRange(IList<OrderInformation> orders);
        Task UpdateAsync(OrderInformation order);
        Task DeleteAsync(long id);
        Task<int> SaveChangesAsync();

        // Just for SeedWork
        bool HasData();

    }
}

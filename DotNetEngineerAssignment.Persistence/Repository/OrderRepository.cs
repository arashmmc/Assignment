using DotNetEngineerAssignment.Core.Domain.Entity;
using DotNetEngineerAssignment.Core.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetEngineerAssignment.Persistence
{
    public class OrderRepository : DbContext, IOrderRepository
    {
        private readonly OrderDbContext _orderDbContext;
        public OrderRepository(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<IEnumerable<OrderInformation>> GetAllAsync() =>
            await Task.FromResult(_orderDbContext.OrderInformations.Include(i => i.Items).ToList());

        public async Task<OrderInformation> GetByIdAsync(long id) =>
            await _orderDbContext.OrderInformations
                .Include(i => i.Items)
                .FirstOrDefaultAsync(i => i.OrderId == id);

        public async Task CreateAsync(OrderInformation order) => await _orderDbContext.AddAsync(order);

        public async Task AddRange(IList<OrderInformation> orders) =>
            await _orderDbContext.OrderInformations.AddRangeAsync(orders);

        public async Task UpdateAsync(OrderInformation order)
        {
            _orderDbContext.Entry(order).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(long id)
        {
            var item = await GetByIdAsync(id);
            _orderDbContext.OrderInformations.Remove(item);
        }

        public async Task<int> SaveChangesAsync() => await _orderDbContext.SaveChangesAsync();

        public bool HasData() => _orderDbContext.OrderInformations.Any();

    }
}

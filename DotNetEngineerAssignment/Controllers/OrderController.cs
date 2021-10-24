using DotNetEngineerAssignment.Application.SeedWork;
using DotNetEngineerAssignment.Application.Services.Contracts;
using DotNetEngineerAssignment.Core.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetEngineerAssignment.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ISeedDatabaseService _seedDatabaseService;

        public OrderController(
            IOrderService orderService,
            ISeedDatabaseService seedDatabaseService)
        {
            _orderService = orderService;
            _seedDatabaseService = seedDatabaseService;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderInformation>> GetAllAsync() => await _orderService.GetAllAsync();

        [HttpGet]
        public async Task<OrderInformation> GetById(long id) => await _orderService.GetByIdAsync(id);

        [HttpPost]
        public async Task<RequiredBinWidth> Create(OrderInformation order) => await _orderService.CreateAsync(order);

        [HttpPost]
        public async Task Update(OrderInformation order) => await _orderService.UpdateAsync(order);

        [HttpPost]
        public async Task UpdateOrderItemInfoAsync(OrderItemInfo orderItemInfo) => await _orderService.UpdateOrderItemInfoAsync(orderItemInfo);

        [HttpPost]
        public async Task Delete(long id) => await _orderService.DeleteAsync(id);

        [HttpPost]
        public async Task<string> SeedDatabase() => await _seedDatabaseService.Do();

    }
}

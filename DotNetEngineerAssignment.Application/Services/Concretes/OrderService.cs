using DotNetEngineerAssignment.Application.BusinessContexts;
using DotNetEngineerAssignment.Application.Services.Contracts;
using DotNetEngineerAssignment.Core.Domain;
using DotNetEngineerAssignment.Core.Domain.Entity;
using DotNetEngineerAssignment.Core.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetEngineerAssignment.Application.Services.Concretes
{
    public class OrderService : IOrderService
    {
        private readonly IProductTypeStrategyService _productTypeStrategyContext;
        private readonly IOrderRepository _orderRepository;
        private readonly IServiceProvider _serviceProvider;
        public OrderService(
          IOrderRepository orderRepository,
          IServiceProvider serviceProvider,
          IProductTypeStrategyService productTypeStrategyContext)
        {
            _orderRepository = orderRepository;
            _serviceProvider = serviceProvider;
            _productTypeStrategyContext = productTypeStrategyContext;
        }

        public async Task<OrderInformation> GetByIdAsync(long id) => await _orderRepository.GetByIdAsync(id);

        public async Task<IEnumerable<OrderInformation>> GetAllAsync() => await _orderRepository.GetAllAsync();

        public async Task<RequiredBinWidth> CreateAsync(OrderInformation order)
        {
            CalculateRequiredWith(order);

            await _orderRepository.CreateAsync(order);
            await _orderRepository.SaveChangesAsync();

            var result = new RequiredBinWidth
            {
                MinimumRequiredBinWidth = order.RequiredBinWidth
            };

            return await Task.FromResult(result);
        }

        public async Task UpdateAsync(OrderInformation order)
        {
            var currentOrder = await _orderRepository.GetByIdAsync(order.OrderId);
            CalculateRequiredWith(currentOrder);

            await _orderRepository.UpdateAsync(currentOrder);
            await _orderRepository.SaveChangesAsync();
        }

        public async Task UpdateOrderItemInfoAsync(OrderItemInfo orderItemInfo)
        {
            var currentOrder = await _orderRepository.GetByIdAsync(orderItemInfo.OrderId);
            var item = currentOrder.Items.Find(i => i.Id == orderItemInfo.Id);

            item.ProductType = orderItemInfo.ProductType;
            item.Quantity = orderItemInfo.Quantity;

            CalculateRequiredWith(currentOrder);

            await _orderRepository.UpdateAsync(currentOrder);
            await _orderRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            await _orderRepository.DeleteAsync(id);
            await _orderRepository.SaveChangesAsync();
        }

        private void CalculateRequiredWith(OrderInformation order)
        {
            foreach (var item in order.Items)
            {
                var obj = (IProduct)ActivatorUtilities.CreateInstance(_serviceProvider, _productTypeStrategyContext.Strategies[item.ProductType]);

                order.RequiredBinWidth += obj.CalculateWidth(item.Quantity);
            }
        }
    }
}

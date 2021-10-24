using DotNetEngineerAssignment.Core.Domain.Entity;
using DotNetEngineerAssignment.Core.Domain.Repository;
using DotNetEngineerAssignment.Domain.Eums;
using DotNetEngineerAssignment.Resource;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetEngineerAssignment.Application.SeedWork
{
    public class SeedDatabaseService : ISeedDatabaseService
    {
        private readonly IOrderRepository _orderRepository;
        public SeedDatabaseService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<string> Do()
        {
            if (_orderRepository.HasData()) return $"{MessagesEN.DataExists}";

            var orderInfos = new List<OrderInformation>
            {
                new OrderInformation
                    {
                        Items = new List<OrderItemInfo>
                            {
                               new OrderItemInfo {
                                   ProductType = ProductType.PhotoBook,
                                   Quantity = 1
                               },
                               new OrderItemInfo {
                                   ProductType = ProductType.Calendar,
                                   Quantity = 1
                               },
                               new OrderItemInfo {
                                   ProductType = ProductType.Mug,
                                   Quantity = 1,
                               },
                            }
                    },
                new OrderInformation
                    {
                        Items = new List<OrderItemInfo>
                            {
                               new OrderItemInfo {
                                   ProductType = ProductType.PhotoBook,
                                   Quantity = 1
                               },
                               new OrderItemInfo {
                                   ProductType = ProductType.Calendar,
                                   Quantity = 1
                               },
                               new OrderItemInfo {
                                   ProductType = ProductType.Mug,
                                   Quantity = 2,
                               },
                            }
                    }
                };

            await _orderRepository.AddRange(orderInfos);
            await _orderRepository.SaveChangesAsync();

            return await Task.FromResult($"{MessagesEN.SeedingFinished}");
        }
    }
}

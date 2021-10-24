using DotNetEngineerAssignment.Application.Services.Contracts;
using DotNetEngineerAssignment.Core.Domain.Entity;
using DotNetEngineerAssignment.Domain.Eums;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace DotNetEngineerAssignment.Tests
{
    public class UnitTest
    {
        private readonly IOrderService _orderService;

        public UnitTest(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Fact]
        public async Task When_There_Are_OnePhotoBook_TwoCalendars_OneMug_RequiredBinWidth_Should_Be_133()
        {
            // Arrange
            var order = new OrderInformation
            {
                Items = new List<OrderItemInfo>
                                    {
                                        new OrderItemInfo
                                        {
                                            ProductType = ProductType.PhotoBook,
                                            Quantity = 1
                                        },
                                        new OrderItemInfo
                                        {
                                            ProductType = ProductType.Calendar,
                                            Quantity = 2
                                        },
                                         new OrderItemInfo
                                        {
                                            ProductType = ProductType.Mug,
                                            Quantity = 1
                                        }
                                    }
            };

            // Act
            await _orderService.CreateAsync(order);

            //Assert
            order.RequiredBinWidth.ShouldBe(133);
        }

        [Fact]
        public async Task When_There_Are_OnePhotoBook_TwoCalendars_OneMug_RequiredBinWidth_Adding_One_Extra_Mug_Should_Not_Change_The_BinSize()
        {
            // Arrange
            var orderA = new OrderInformation
            {
                Items = new List<OrderItemInfo>
                                    {
                                        new OrderItemInfo
                                        {
                                            ProductType = ProductType.PhotoBook,
                                            Quantity = 1
                                        },
                                        new OrderItemInfo
                                        {
                                            ProductType = ProductType.Calendar,
                                            Quantity = 2
                                        },
                                         new OrderItemInfo
                                        {
                                            ProductType = ProductType.Mug,
                                            Quantity = 1
                                        }
                                    }
            };

            var orderB = new OrderInformation
            {
                Items = new List<OrderItemInfo>
                                    {
                                        new OrderItemInfo
                                        {
                                            ProductType = ProductType.PhotoBook,
                                            Quantity = 1
                                        },
                                        new OrderItemInfo
                                        {
                                            ProductType = ProductType.Calendar,
                                            Quantity = 2
                                        },
                                         new OrderItemInfo
                                        {
                                            ProductType = ProductType.Mug,
                                            Quantity = 2
                                        }
                                    }
            };

            // Act
            await _orderService.CreateAsync(orderA);
            await _orderService.CreateAsync(orderB);

            //Assert
            orderA.RequiredBinWidth.ShouldBe(orderB.RequiredBinWidth);
        }

        [Fact]
        public async Task When_There_Are_OnePhotoBook_TwoCalendars_FiveMugs_RequiredBinWidth_Should_Be_227()
        {
            // Arrange
            var orderA = new OrderInformation
            {
                Items = new List<OrderItemInfo>
                                    {
                                        new OrderItemInfo
                                        {
                                            ProductType = ProductType.PhotoBook,
                                            Quantity = 1
                                        },
                                        new OrderItemInfo
                                        {
                                            ProductType = ProductType.Calendar,
                                            Quantity = 2
                                        },
                                         new OrderItemInfo
                                        {
                                            ProductType = ProductType.Mug,
                                            Quantity = 5
                                        }
                                    }
            };

            // Act
            await _orderService.CreateAsync(orderA);

            //Assert
            orderA.RequiredBinWidth.ShouldBe(227);
        }

        [Fact]
        public async Task When_There_Are_OnePhotoBook_TwoCalendars_OneMug_RequiredBinWidth_Adding_4_Extra_Mugs_Should_Change_The_BinSize()
        {
            // Arrange
            var orderA = new OrderInformation
            {
                Items = new List<OrderItemInfo>
                                    {
                                        new OrderItemInfo
                                        {
                                            ProductType = ProductType.PhotoBook,
                                            Quantity = 1
                                        },
                                        new OrderItemInfo
                                        {
                                            ProductType = ProductType.Calendar,
                                            Quantity = 2
                                        },
                                         new OrderItemInfo
                                        {
                                            ProductType = ProductType.Mug,
                                            Quantity = 1
                                        }
                                    }
            };

            var orderB = new OrderInformation
            {
                Items = new List<OrderItemInfo>
                                    {
                                        new OrderItemInfo
                                        {
                                            ProductType = ProductType.PhotoBook,
                                            Quantity = 1
                                        },
                                        new OrderItemInfo
                                        {
                                            ProductType = ProductType.Calendar,
                                            Quantity = 2
                                        },
                                         new OrderItemInfo
                                        {
                                            ProductType = ProductType.Mug,
                                            Quantity = 5
                                        }
                                    }
            };

            // Act
            await _orderService.CreateAsync(orderA);
            await _orderService.CreateAsync(orderB);

            //Assert
            orderB.RequiredBinWidth.ShouldBeGreaterThan(orderA.RequiredBinWidth);
        }
    }
}

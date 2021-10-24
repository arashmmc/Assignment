using System;
using System.Collections.Generic;
using DotNetEngineerAssignment.Core;
using DotNetEngineerAssignment.Core.Domain.Entity;
using DotNetEngineerAssignment.Domain.Eums;

namespace DotNetEngineerAssignment.Application.BusinessContexts
{
    public class ProductTypeStrategyService : IProductTypeStrategyService
    {
        private readonly IDictionary<ProductType, Type> _strategies;
        public ProductTypeStrategyService()
        {
            _strategies = new Dictionary<ProductType, Type> {
                { ProductType.PhotoBook,  typeof(PhotoBook)},
                { ProductType.Calendar,typeof(Calendar)},
                { ProductType.Canvas,typeof(Canvas)},
                { ProductType.Card,typeof(Card)},
                { ProductType.Mug,typeof(Mug)}
               };

        }

        public IDictionary<ProductType, Type> Strategies => _strategies;
    }
}

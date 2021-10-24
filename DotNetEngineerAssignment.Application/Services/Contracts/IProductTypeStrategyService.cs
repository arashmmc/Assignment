using DotNetEngineerAssignment.Domain.Eums;
using System;
using System.Collections.Generic;

namespace DotNetEngineerAssignment.Application.BusinessContexts
{
    public interface IProductTypeStrategyService
    {
        IDictionary<ProductType, Type> Strategies { get;  }
    }
}

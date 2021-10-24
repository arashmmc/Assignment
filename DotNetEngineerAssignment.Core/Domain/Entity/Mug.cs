using DotNetEngineerAssignment.Core.Domain;
using System;

namespace DotNetEngineerAssignment.Core
{
    public class Mug : IProduct
    {
        public decimal CalculateWidth(int quantity)
        {
            return (decimal)(Math.Ceiling(quantity / 4d) * 94);
        }
    }

}

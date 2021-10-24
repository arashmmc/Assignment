namespace DotNetEngineerAssignment.Core.Domain.Entity
{
    public class Canvas : IProduct
    {
        public decimal CalculateWidth(int quantity)
        {
            return (decimal)16 * quantity;
        }
    }

}

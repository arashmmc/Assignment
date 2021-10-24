namespace DotNetEngineerAssignment.Core.Domain.Entity
{
    public class Calendar : IProduct
    {
        public decimal CalculateWidth(int quantity)
        {
            return (decimal)10 * quantity;
        }
    }

}

namespace DotNetEngineerAssignment.Core.Domain.Entity
{
    public class Card : IProduct
    {
        public decimal CalculateWidth(int quantity)
        {
            return (decimal)4.7 * quantity;
        }
    }

}

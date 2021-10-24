namespace DotNetEngineerAssignment.Core.Domain.Entity
{
    public class PhotoBook : IProduct
    {
        public decimal CalculateWidth(int quantity)
        {
            return (decimal)19 * quantity;
        }
    }

}

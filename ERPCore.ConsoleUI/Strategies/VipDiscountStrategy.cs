namespace ERPCore.ConsoleUI.Strategies
{
    public class VipDiscountStrategy : IDiscountStrategy
    {
        public decimal CalculateFinalPrice(decimal totalAmount)
        {
            return totalAmount * 0.90m;
        }
    }
}



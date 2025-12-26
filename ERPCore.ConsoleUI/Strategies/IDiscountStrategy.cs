namespace ERPCore.ConsoleUI.Strategies;

public interface IDiscountStrategy
{
    decimal CalculateFinalPrice(decimal OriginalPrice);
}
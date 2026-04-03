using ERPCore.ConsoleUI.Models;
using ERPCore.ConsoleUI.Strategies;

namespace ERPCore.Tests;

public class VipDiscountStrategyTests
{
    private readonly VipDiscountStrategy _strategy = new();

    [Fact]
    public void CalculateFinalPrice_AppliesTenPercentDiscount()
    {
        decimal result = _strategy.CalculateFinalPrice(1000m);
        Assert.Equal(900m, result);
    }

    [Fact]
    public void CalculateFinalPrice_ReturnsZeroForZeroAmount()
    {
        decimal result = _strategy.CalculateFinalPrice(0m);
        Assert.Equal(0m, result);
    }

    [Fact]
    public void CalculateFinalPrice_HandlesDecimalAmounts()
    {
        decimal result = _strategy.CalculateFinalPrice(199.99m);
        Assert.Equal(179.991m, result);
    }
}

public class SalesOrderTests
{
    [Fact]
    public void GetFinalPrice_UsesInjectedStrategy()
    {
        var strategy = new VipDiscountStrategy();
        var order = new SalesOrder(strategy) { TotalAmount = 500m };

        decimal finalPrice = order.GetFinalPrice();

        Assert.Equal(450m, finalPrice);
    }

    [Fact]
    public void GetFinalPrice_ReturnsFullAmountWithNoDiscountStrategy()
    {
        var strategy = new NoDiscountStrategy();
        var order = new SalesOrder(strategy) { TotalAmount = 300m };

        decimal finalPrice = order.GetFinalPrice();

        Assert.Equal(300m, finalPrice);
    }
}

// Hjälpklass för test — ingen rabatt
file class NoDiscountStrategy : IDiscountStrategy
{
    public decimal CalculateFinalPrice(decimal totalAmount) => totalAmount;
}

using System;
using System.Collections.Generic;
using ERPCore.ConsoleUI.Strategies;
using System;
using System.Collections.Generic;
using ERPCore.ConsoleUI.Strategies;

namespace ERPCore.ConsoleUI.Models
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderRow> OrderRows { get; set; } = new();

        public decimal TotalAmount { get; set; }

        private readonly IDiscountStrategy _discountStrategy;
        
        public SalesOrder(IDiscountStrategy strategy)
        {
            _discountStrategy = strategy;
        }

        public decimal GetFinalPrice()
        {
            return _discountStrategy.CalculateFinalPrice(TotalAmount);
        }
    }
}

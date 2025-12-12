using System;
using System.Collections.Generic;

namespace ERPCore.ConsoleUI.Models;

public class SalesOrder
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    public List<OrderRow> OrderRows { get; set; }
}
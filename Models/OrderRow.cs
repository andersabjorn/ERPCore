namespace ERPCore.ConsoleUI.Models;

public class OrderRow
{
    public int Id { get; set; }
    public int SalesOrderId { get; set; }
    public SalesOrder SalesOrder { get; set; }
    // Vilken produkt är jag
    public int ProductId{ get; set; }
    public Product Product { get; set; }
    
    // Historik: Vad kostar den och hur mycket köpte man?
    public int Quantity { get; set; }
    public decimal Price  { get; set; }
}
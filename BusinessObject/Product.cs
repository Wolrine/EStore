namespace BusinessObject;

public class Product
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public required string ProductName { get; set; }
    public required string Weight { get; set; }
    public double UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}

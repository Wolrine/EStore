namespace BusinessObject;

public class OrderDetail
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public double UnitPrice { get; set; }
    public int Quantity { get; set; }
    public float Discount { get; set; }
    public required Order Order { get; set; }
    public required Product Product { get; set; }
}

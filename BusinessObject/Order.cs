namespace BusinessObject;

public class Order
{
    public int OrderId { get; set; }
    public int MemberId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public double? Freight { get; set; }
    public required Member Member { get; set; }
}

using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class OrderDetailDAO
{
    #region Instance
    private static OrderDetailDAO? instance = null;
    private static readonly object instanceLock = new();
    private OrderDetailDAO() { }
    public static OrderDetailDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new OrderDetailDAO();
                }
                return instance;
            }
        }
    }
    #endregion

    public EStoreContext storeContext = new();

    public void Create(OrderDetail orderDetail)
    {
        storeContext.OrderDetails.AddAsync(orderDetail);
        storeContext.SaveChanges();
    }

    public void Delete(int orderId, int productId)
    {
        storeContext.OrderDetails
            .Where(e => e.OrderId == orderId && e.ProductId == productId)
            .ExecuteDeleteAsync();
        storeContext.SaveChanges();
    }

    public OrderDetail GetById(int orderId, int productId) =>
        storeContext.OrderDetails
            .First(e => e.OrderId == orderId && e.ProductId == productId);

    public IEnumerable<OrderDetail> Read() =>
        storeContext.OrderDetails
            .ToListAsync().Result;

    public void Update(OrderDetail orderDetail)
    {
        storeContext.OrderDetails.Update(orderDetail);
        storeContext.SaveChanges();
    }
}

using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class OrderDAO
{
    #region Instance
    private static OrderDAO? instance = null;
    private static readonly object instanceLock = new();
    private OrderDAO() { }
    public static OrderDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }
    }
    #endregion

    public EStoreContext storeContext = new();

    public void Create(Order order)
    {
        storeContext.Orders.AddAsync(order);
        storeContext.SaveChanges();
    }

    public void Delete(int orderId)
    {
        storeContext.Orders
            .Where(e => e.OrderId == orderId)
            .ExecuteDeleteAsync();
        storeContext.SaveChanges();
    }

    public Order GetById(int id) =>
        storeContext.Orders
            .First(e => e.OrderId == id);

    public IEnumerable<Order> Read() =>
        storeContext.Orders
            .ToListAsync().Result;

    public void Update(Order order)
    {
        storeContext.Orders.Update(order);
        storeContext.SaveChanges();
    }
}

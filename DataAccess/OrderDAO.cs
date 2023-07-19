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

    private EStoreContext context = new();

    public void Create(Order order)
    {
        context.Orders.AddAsync(order);
        context.SaveChanges();
    }

    public void Delete(int orderId)
    {
        context.Orders
            .Where(e => e.OrderId == orderId)
            .ExecuteDeleteAsync();
        context.SaveChanges();
    }

    public Order GetById(int id)
    {
        var order = context.Orders.First(e => e.OrderId == id);
        if (order.Member != null)
            context.Entry(order).Reference(e => e.Member).LoadAsync();
        return order;
    }

    public IEnumerable<Order> Read()
    {
        var orders = context.Orders.ToListAsync().Result;
        foreach (var order in orders)
        {
            if (order.Member != null)
                context.Entry(order).Reference(e => e.Member).LoadAsync();
        }
        return orders;
    }

    public void Update(Order order)
    {
        using var context = new EStoreContext();
        context.Orders.Update(order);
        context.SaveChanges();
    }
}

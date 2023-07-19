using BusinessObject;

namespace DataAccess.Repository;

public class OrderDetailRepository : IOrderDetailRepository
{
    public void Create(OrderDetail entity) =>
        OrderDetailDAO.Instance.Create(entity);

    public void Delete(int orderId, int productId) =>
        OrderDetailDAO.Instance.Delete(orderId, productId);

    public OrderDetail? GetById(int orderId, int productId) =>
        OrderDetailDAO.Instance.GetById(orderId, productId);

    public IEnumerable<OrderDetail> Read() =>
        OrderDetailDAO.Instance.Read();

    public void Update(OrderDetail entity) =>
        OrderDetailDAO.Instance.Update(entity);
}

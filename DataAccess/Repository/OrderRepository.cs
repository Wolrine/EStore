using BusinessObject;

namespace DataAccess.Repository;

public class OrderRepository : IOrderRepository
{
    public void Create(Order entity) =>
        OrderDAO.Instance.Create(entity);

    public void Delete(int id) =>
        OrderDAO.Instance.Delete(id);

    public Order? GetById(int id) =>
        OrderDAO.Instance.GetById(id);

    public IEnumerable<Order> Read() =>
        OrderDAO.Instance.Read();

    public void Update(Order entity) =>
        OrderDAO.Instance.Update(entity);
}

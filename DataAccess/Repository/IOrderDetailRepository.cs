using BusinessObject;

namespace DataAccess.Repository;

public interface IOrderDetailRepository : IGenericRepository<OrderDetail>
{
    void Delete(int orderId, int productId);
    OrderDetail GetById(int orderId, int productId);
}

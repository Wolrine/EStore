using BusinessObject;

namespace DataAccess.Repository;

public interface IOrderRepository : IGenericRepository<Order>
{
    void Delete(int id);
    Order GetById(int id);
}

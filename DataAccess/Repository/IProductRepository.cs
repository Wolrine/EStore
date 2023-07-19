using BusinessObject;

namespace DataAccess.Repository;

public interface IProductRepository : IGenericRepository<Product>
{
    void Delete(int id);
    Product GetById(int id);
}

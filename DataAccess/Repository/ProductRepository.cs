using BusinessObject;

namespace DataAccess.Repository;

public class ProductRepository : IProductRepository
{
    public void Create(Product entity) =>
        ProductDAO.Instance.Create(entity);

    public void Delete(int id) =>
        ProductDAO.Instance.Delete(id);

    public Product? GetById(int id) =>
        ProductDAO.Instance.GetById(id);

    public IEnumerable<Product> Read() =>
        ProductDAO.Instance.Read();

    public void Update(Product entity) =>
        ProductDAO.Instance.Update(entity);
}

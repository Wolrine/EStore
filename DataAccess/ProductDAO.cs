using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ProductDAO
{
    #region Instance
    private static ProductDAO? instance = null;
    private static readonly object instanceLock = new();
    private ProductDAO() { }
    public static ProductDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }
    }
    #endregion

    public EStoreContext storeContext = new();

    public void Create(Product product)
    {
        storeContext.Products.AddAsync(product);
        storeContext.SaveChanges();
    }

    public void Delete(int productId)
    {
        storeContext.Products
            .Where(e => e.ProductId == productId)
            .ExecuteDeleteAsync();
        storeContext.SaveChanges();
    }

    public Product GetById(int id) =>
        storeContext.Products
            .First(e => e.ProductId == id);

    public IEnumerable<Product> Read() =>
        storeContext.Products
            .ToListAsync().Result;

    public void Update(Product product)
    {
        storeContext.Products.Update(product);
        storeContext.SaveChanges();
    }
}

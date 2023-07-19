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

    private EStoreContext context = new();

    public void Create(Product product)
    {
        context.Products.AddAsync(product);
        context.SaveChanges();
    }

    public void Delete(int productId)
    {
        context.Products
            .Where(e => e.ProductId == productId)
            .ExecuteDeleteAsync();
        context.SaveChanges();
    }

    public Product GetById(int id)
    {
        return context.Products.First(e => e.ProductId == id);
    }

    public IEnumerable<Product> Read()
    {
        return context.Products.ToListAsync().Result;
    }

    public void Update(Product product)
    {
        context = new EStoreContext();
        context.Products.Update(product);
        context.SaveChanges();
    }
}

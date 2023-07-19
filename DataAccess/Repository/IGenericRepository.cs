namespace DataAccess.Repository;

public interface IGenericRepository<T> where T : class
{
    void Create(T entity);
    IEnumerable<T> Read();
    void Update(T entity);
    //void Delete(int id);
}

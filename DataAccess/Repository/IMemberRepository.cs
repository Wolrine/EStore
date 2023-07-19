using BusinessObject;

namespace DataAccess.Repository;

public interface IMemberRepository : IGenericRepository<Member>
{
    void Delete(int id);
    Member GetById(int id);
}

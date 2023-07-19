using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class MemberDAO
{
    #region Instance
    private static MemberDAO? instance = null;
    private static readonly object instanceLock = new();
    private MemberDAO() { }
    public static MemberDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new MemberDAO();
                }
                return instance;
            }
        }
    }
    #endregion

    public void Create(Member member)
    {
        using var context = new EStoreContext();
        context.Members.AddAsync(member);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        using var context = new EStoreContext();
        context.Members
            .Where(e => e.MemberId == id)
            .ExecuteDeleteAsync();
        context.SaveChanges();
    }

    public Member GetById(int id)
    {
        using var context = new EStoreContext();
        return context.Members.First(e => e.MemberId == id);
    }

    public IEnumerable<Member> Read()
    {
        using var context = new EStoreContext();
        return context.Members.ToListAsync().Result;
    }

    public void Update(Member member)
    {
        using var context = new EStoreContext();
        context.Members.Update(member);
        context.SaveChanges();
    }
}
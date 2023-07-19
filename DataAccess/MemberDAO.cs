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

    private EStoreContext context = new();

    public void Create(Member member)
    {
        context.Members.AddAsync(member);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        context.Members
            .Where(e => e.MemberId == id)
            .ExecuteDeleteAsync();
        context.SaveChanges();
    }

    public Member GetById(int id)
    {
        return context.Members.First(e => e.MemberId == id);
    }

    public IEnumerable<Member> Read()
    {
        return context.Members.ToListAsync().Result;
    }

    public void Update(Member member)
    {
        context = new EStoreContext();
        context.Members.Update(member);
        context.SaveChanges();
    }
}
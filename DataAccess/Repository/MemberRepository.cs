using BusinessObject;

namespace DataAccess.Repository;

public class MemberRepository : IMemberRepository
{
    public void Create(Member member) =>
        MemberDAO.Instance.Create(member);

    public void Delete(int id) =>
        MemberDAO.Instance.Delete(id);

    public Member? GetById(int id) =>
        MemberDAO.Instance.GetById(id);

    public IEnumerable<Member> Read() =>
        MemberDAO.Instance.Read();

    public void Update(Member member) =>
        MemberDAO.Instance.Update(member);
}

using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MyStoreWinApp.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IList<Member> _loggers;

        private MemberRepository repository = new();

        // GET: MemberController
        public IEnumerable<Member> Get()
        {
            return repository.Read();
        }

        // GET: MemberController/Details/5
        public Member Details(int id)
        {
            try
            {
                return repository.GetById(id);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: MemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            try
            {
                repository.Create(member);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(repository.GetById(id));
            }
            catch
            {
                return NotFound();
            }

        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Member member)
        {
            try
            {
                if (id != member.MemberId) return NotFound();
                repository.Update(member);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(repository.GetById(id));
            }
            catch
            {
                return View();
            }
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

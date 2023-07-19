using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MyStoreWinApp.Controllers
{
    public class MemberController : Controller
    {
        private MemberRepository repository = new();

        // GET: MemberController
        public ActionResult Index()
        {
            try
            {
                return View(repository.Read());
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberController/Details/5
        public ActionResult Details(int id)
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

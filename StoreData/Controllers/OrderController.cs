using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyStoreWinApp.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private OrderRepository repository = new();

        // GET: OrderController
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

        // GET: OrderController/Details/5
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

        // GET: OrderController/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = from member in new MemberRepository().Read()
                               select new SelectListItem
                               {
                                   Text = $"{member.Email} ({member.MemberId})",
                                   Value = member.MemberId.ToString()
                               };
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            try
            {
                repository.Create(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.MemberId = from member in new MemberRepository().Read()
                                   select new SelectListItem
                                   {
                                       Text = $"{member.Email} ({member.MemberId})",
                                       Value = member.MemberId.ToString()
                                   };
                return View(repository.GetById(id));
            }
            catch
            {
                return NotFound();
            }

        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                if (id != order.OrderId) return NotFound();
                repository.Update(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
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

        // POST: OrderController/Delete/5
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

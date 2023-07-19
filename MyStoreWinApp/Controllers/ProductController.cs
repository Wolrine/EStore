using BusinessObject;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MyStoreWinApp.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository repository = new();

        // GET: ProductController
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

        // GET: ProductController/Details/5
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

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                repository.Create(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
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

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                if (id != product.ProductId) return NotFound();
                repository.Update(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
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

        // POST: ProductController/Delete/5
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

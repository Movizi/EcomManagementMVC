using EcomManagement.Contracts;
using EcomManagement.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace EcomManagement.Controllers
{
    public class CategoryController : Controller
    {
        #region Injection
        private readonly ICrudRepository<Category> _repo;

        public CategoryController(ICrudRepository<Category> repo)
        {
            _repo = repo;
        }
        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> result = _repo.Get();
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category entity)
        {
            Category result = _repo.Add(entity);

            return RedirectToAction("Index");
        }
    }
}

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


        #region Pages
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category category = _repo.GetById(id);
            return View(category);
        }

        #endregion

        #region CRUD Operations
        [HttpPost]
        public IActionResult AddCategory(Category entity)
        {
            _repo.Add(entity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category entity)
        {
            _repo.Update(entity);

            return RedirectToAction("Index");
        }

        #endregion
    }
}

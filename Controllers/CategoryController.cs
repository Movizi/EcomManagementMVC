using EcomManagement.Contracts;
using EcomManagement.Models.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace EcomManagement.Controllers
{
    [Authorize]
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

        #endregion

        #region CRUD Operations
        [HttpPost]
        public IActionResult AddCategory(Category entity)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var add = _repo.Add(entity);

            if(add == null)
            {
                ModelState.AddModelError(string.Empty, "Something Went Wrong");

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category entity)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            _repo.Update(entity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            _repo.Delete(id);

            return RedirectToAction("Index");
        }
        #endregion
    }
}

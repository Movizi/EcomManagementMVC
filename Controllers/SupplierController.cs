using AutoMapper;
using EcomManagement.Contracts;
using EcomManagement.HelperMethods;
using EcomManagement.Models.Categories;
using EcomManagement.Models.Shippers;
using EcomManagement.Models.Suppliers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcomManagement.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        #region Injection
        private readonly ICrudRepository<Supplier> _repo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SupplierController(
            ICrudRepository<Supplier> repo,
            IMapper mapper,
            IWebHostEnvironment webHostEnvironment)
        {
            _repo = repo;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region Pages
        [HttpGet]
        public IActionResult Index()
        {
            var result = _repo.Get();
            return View(result);
        }

        #endregion

        #region CRUD Operations
        [HttpPost]
        public IActionResult AddSupplier(SupplierDto entity)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            string serverFolder = string.Empty;
            string imageUrl = string.Empty;

            if (entity.Image != null)
            {
                string folder = "Images/Supplier/"; // Use forward slashes for paths
                string uniqueFileName = entity.Image.FileName;

                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, folder, uniqueFileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    entity.Image.CopyTo(stream);
                }

                // Now, store the URL ("/Images/Supplier/uniqueFileName") in your database.
                imageUrl = $"/{folder}{uniqueFileName}";
            }

            var request = new Supplier
            {
                SupplierName = entity.SupplierName,
                Description = entity.Description,
                Image = imageUrl
            };

            _repo.Add(request);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateSupplier(SupplierDto entity)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            string serverFolder = string.Empty;
            string imageUrl = string.Empty;

            if (entity.Image != null)
            {
                string folder = "Images/Supplier/"; // Use forward slashes for paths
                string uniqueFileName = entity.Image.FileName;

                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, folder, uniqueFileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    entity.Image.CopyTo(stream);
                }

                // Now, store the URL ("/Images/Supplier/uniqueFileName") in your database.
                imageUrl = $"/{folder}{uniqueFileName}";
            }

            var request = new Supplier
            {
                SupplierID = entity.SupplierID,
                SupplierName = entity.SupplierName,
                Description = entity.Description,
                Image = imageUrl
            };

            _repo.Update(request);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteSupplier(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var entity = _repo.Delete(id);

            var imageName = Path.GetFileName(entity.Image);

            SavingImageHelper.DeleteImage<Supplier>(imageName, _webHostEnvironment);

            return RedirectToAction("Index");
        }

        #endregion

    }
}

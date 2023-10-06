using AutoMapper;
using EcomManagement.Contracts;
using EcomManagement.Models.Categories;
using EcomManagement.Models.Suppliers;
using Microsoft.AspNetCore.Mvc;

namespace EcomManagement.Controllers
{
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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Supplier supplier = _repo.GetById(id);
            return View(supplier);
        }
        #endregion

        #region CRUD Operations
        [HttpPost]
        public IActionResult AddSupplier(SupplierDto entity)
        {
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
        public IActionResult UpdateSupplier(Supplier entity)
        {
            _repo.Update(entity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteSupplier(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
        #endregion

    }
}

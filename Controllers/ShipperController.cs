using AutoMapper;
using EcomManagement.Contracts;
using EcomManagement.HelperMethods;
using EcomManagement.Models.Categories;
using EcomManagement.Models.Shippers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EcomManagement.Controllers
{
    public class ShipperController : Controller
    {
        #region Injection
        private readonly IMapper _mapper;
        private readonly ICrudRepository<Shipper> _repo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ShipperController(
            IMapper mapper,
            ICrudRepository<Shipper> repo,
            IWebHostEnvironment webHostEnvironment

            )
        {
            _mapper = mapper;
            _repo = repo;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region Pages
        public IActionResult Index()
        {
            var result = _repo.Get();
            return View(result);
        }

        #endregion

        #region Crud Opertaions
        [HttpPost]
        public IActionResult AddShipper(ShipperDto entity)
        {
            var request = _mapper.Map<Shipper>(entity);

            if (entity.Image != null)
            {
                request.Image = SavingImageHelper.SaveImageAndGetString<Shipper>(entity.Image, _webHostEnvironment);
            }

            _repo.Add(request);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateShipper(ShipperDto entity)
        {
            var request = _mapper.Map<Shipper>(entity);

            if (entity.Image != null)
            {
                request.Image = SavingImageHelper.SaveImageAndGetString<Shipper>(entity.Image, _webHostEnvironment);
            }

            _repo.Update(request);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteShipper(int id)
        {
            var entity = _repo.Delete(id);

            var imageName = Path.GetFileName(entity.Image);

            SavingImageHelper.DeleteImage<Shipper>(imageName, _webHostEnvironment);

            return RedirectToAction("Index");
        }
        #endregion
    }
}

using AutoMapper;
using EcomManagement.Contracts;
using EcomManagement.HelperMethods;
using EcomManagement.Models.Categories;
using EcomManagement.Models.Products;
using EcomManagement.Models.Suppliers;
using EcomManagement.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Abstractions;
using System.Security.Cryptography.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace EcomManagement.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        #region Injection

        private readonly ICrudRepository<Product> _productRepository;
        private readonly IProductImageRepository _imageRepository;
        private readonly ICrudRepository<Category> _categoryRepository;
        private readonly ICrudRepository<Supplier> _supplierRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        public ProductController(
            ICrudRepository<Product> productRepository,
            IProductImageRepository imageRepository,
            ICrudRepository<Category> categoryRepository,
            ICrudRepository<Supplier> supplierRepository,
            IWebHostEnvironment webHostEnvironment,
            IMapper mapper
            )
        {
            _productRepository = productRepository;
            _imageRepository = imageRepository;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        #endregion

        #region Pages

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productRepository.Get();

            var result = _mapper.Map<List<ProductViewModel>>(products);

            ViewBag.Categories = _categoryRepository.Get().Select(category => new SelectListItem
            {
                Text = category.CategoryName,
                Value = category.CategoryID.ToString()
            });
            ViewBag.Suppliers = _supplierRepository.Get().Select(supplier => new SelectListItem
            {
                Text = supplier.SupplierName,
                Value = supplier.SupplierID.ToString()
            });

            return View(result);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetById(id);
            var result = _mapper.Map<ProductDto>(product);

            var images = _imageRepository.GetImagesByProductId(id);

            ViewBag.Images = images;

            ViewBag.Categories = _categoryRepository.Get().Select(category => new SelectListItem
            {
                Text = category.CategoryName,
                Value = category.CategoryID.ToString()
            });
            ViewBag.Suppliers = _supplierRepository.Get().Select(supplier => new SelectListItem
            {
                Text = supplier.SupplierName,
                Value = supplier.SupplierID.ToString()
            });

            return View(result);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _productRepository.GetById(id);
            var result = _mapper.Map<ProductDto>(product);

            var images = _imageRepository.GetImagesByProductId(id);

            ViewBag.Images = images;

            return View(result);
        }
        #endregion

        #region CRUD Operations

        [HttpPost]
        public IActionResult AddProduct(ProductDto entity)
        {
            var product = _mapper.Map<Product>(entity);

            var addProduct = _productRepository.Add(product);

            if (addProduct != null && entity.Images != null)
            {
                foreach (var image in entity.Images)
                {
                    var tempImage = new ProductImage
                    {
                        ProductId = addProduct.ProductID,
                        Image = SavingImageHelper.SaveImageAndGetString<Product>(image, _webHostEnvironment)
                    };

                    _imageRepository.Add(tempImage);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductDto entity)
        {
            var product = _mapper.Map<Product>(entity);

            var editProduct = _productRepository.Update(product);

            if(editProduct != null && entity.Images != null)
            {
                var deleteImages = _imageRepository.DeleteImagesByProductID(editProduct.ProductID);

                if (deleteImages)
                {
                    foreach (var image in entity.Images)
                    {
                        var tempImage = new ProductImage
                        {
                            ProductId = editProduct.ProductID,
                            Image = SavingImageHelper.SaveImageAndGetString<Product>(image, _webHostEnvironment)
                        };

                        _imageRepository.Add(tempImage);
                    }
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var deleteProduct = _productRepository.Delete(id);
            
            if (deleteProduct != null)
            {
                _imageRepository.DeleteImagesByProductID(id);
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}

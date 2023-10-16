using AutoMapper;
using EcomManagement.Contracts;
using EcomManagement.HelperMethods;
using EcomManagement.Models.Products;
using EcomManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Abstractions;
using System.Security.Cryptography.Xml;

namespace EcomManagement.Controllers
{
    public class ProductContoller : Controller
    {
        #region Injection

        private readonly ICrudRepository<Product> _productRepository;
        private readonly IProductImageRepository _imageRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        public ProductContoller(
            ICrudRepository<Product> productRepository,
            IProductImageRepository imageRepository,
            IWebHostEnvironment webHostEnvironment,
            IMapper mapper
            )
        {
            _productRepository = productRepository;
            _imageRepository = imageRepository;
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

            return View(result);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetById(id);

            var result = _mapper.Map<ProductDto>(product);

            var images = _imageRepository.GetImagesByProductId(id);

            foreach (var image in images)
            {
                var tempImage = new ProductImageDto
                {
                    Image = SavingImageHelper.GetFormFileFromPath(image.Image)
                };
                    
                result.Images.Add(tempImage);
            }

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
                        Image = SavingImageHelper.SaveImageAndGetString<Product>(image.Image, _webHostEnvironment)
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
                            Image = SavingImageHelper.SaveImageAndGetString<Product>(image.Image, _webHostEnvironment)
                        };

                        _imageRepository.Add(tempImage);
                    }
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var deleteProduct = _productRepository.Delete(productId);
            
            if (deleteProduct != null)
            {
                _imageRepository.DeleteImagesByProductID(productId);
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}

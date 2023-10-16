using EcomManagement.Contracts;
using EcomManagement.Data;
using EcomManagement.Models.Products;
using System.Security.Cryptography.Xml;

namespace EcomManagement.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        #region Injection

        private readonly AppDbContext _context;
        public ProductImageRepository(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        public ProductImage Add(ProductImage entity)
        {
            try
            {
                _context.ProductImages.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ProductImage Delete(int id)
        {
            try
            {
                var entity = _context.ProductImages.FirstOrDefault(x => x.ImageId == id);
                if (entity != null)
                {
                    _context.ProductImages.Remove(entity);
                    _context.SaveChanges();

                    return entity;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool DeleteImagesByProductID(int productId)
        {
            try
            {
                var images = _context.ProductImages.Where(x => x.ProductId == productId).ToList();
                
                if (images != null)
                {
                    _context.ProductImages.RemoveRange(images);
                    _context.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ProductImage> Get()
        {
            try
            {
                return _context.ProductImages.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ProductImage GetById(int id)
        {
            try
            {
                return _context.ProductImages.FirstOrDefault(x => x.ImageId == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ProductImage> GetImagesByProductId(int productId)
        {
            try
            {
                return _context.ProductImages.Where(x => x.ProductId == productId).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ProductImage Update(ProductImage entity)
        {
            try
            {
                _context.ProductImages.Update(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

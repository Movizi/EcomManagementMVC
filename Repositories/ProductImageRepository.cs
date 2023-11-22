using EcomManagement.Contracts;
using EcomManagement.Data;
using EcomManagement.Models.Products;

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

        #region Main Operations
        public List<ProductImage> Get()
        {
            return _context.ProductImages.ToList();
        }

        public ProductImage GetById(int id)
        {
            if (id == 0)
                return null;

            return _context.ProductImages.FirstOrDefault(x => x.ImageId == id);
        }

        public List<ProductImage> GetImagesByProductId(int productId)
        {
            if (productId == 0)
                return null;

            return _context.ProductImages.Where(x => x.ProductId == productId).ToList();
        }

        public ProductImage Add(ProductImage entity)
        {
            if (entity == null)
                return null;

            _context.ProductImages.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public ProductImage Update(ProductImage entity)
        {
            if (entity == null)
                return null;

            _context.ProductImages.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public ProductImage Delete(int id)
        {
            if (id == 0)
                return null;

            var entity = _context.ProductImages.FirstOrDefault(x => x.ImageId == id);

            if (entity != null)
            {
                _context.ProductImages.Remove(entity);
                _context.SaveChanges();

                return entity;
            }

            return null;
        }

        public bool DeleteImagesByProductID(int productId)
        {
            if (productId == 0)
                return false;

            var images = _context.ProductImages.Where(x => x.ProductId == productId).ToList();

            if (images != null)
            {
                _context.ProductImages.RemoveRange(images);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        #endregion
    }
}

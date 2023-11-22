using EcomManagement.Contracts;
using EcomManagement.Data;
using EcomManagement.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace EcomManagement.Repositories
{
    public class ProductRepository : ICrudRepository<Product>
    {

        #region Injection

        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Main Operations
        public List<Product> Get()
        {
            return _context.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .ToList();
        }

        public Product GetById(int id)
        {
            if (id == 0)
                return null;

            return _context.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .FirstOrDefault(x => x.ProductID == id);
        }
        public Product Add(Product entity)
        {
            if (entity == null)
                return null;

            _context.Products.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public Product Update(Product entity)
        {
            if (entity == null)
                return null;

            _context.Products.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public Product Delete(int id)
        {
            if (id == 0)
                return null;

            var entity = _context.Products.FirstOrDefault(x => x.ProductID == id);

            if (entity != null)
            {
                _context.Products.Remove(entity);
                _context.SaveChanges();

                return entity;
            }

            return null;

        }

        #endregion
    }
}

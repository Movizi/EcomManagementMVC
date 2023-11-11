using EcomManagement.Contracts;
using EcomManagement.Data;
using EcomManagement.Models.Products;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

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

        public Product Add(Product entity)
        {
            try
            {
                _context.Products.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Product Delete(int id)
        {
            try
            {
                var entity = _context.Products.FirstOrDefault(x => x.ProductID == id);

                if (entity != null)
                {
                    _context.Products.Remove(entity);
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

        public List<Product> Get()
        {
            try
            {
                return _context.Products
                    .Include(x => x.Category)
                    .Include(x => x.Supplier)
                    .ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Product GetById(int id)
        {
            try
            {
                return _context.Products
                    .Include(x => x.Category)
                    .Include(x => x.Supplier)
                    .FirstOrDefault(x => x.ProductID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Product Update(Product entity)
        {
            try
            {
                _context.Products.Update(entity);
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

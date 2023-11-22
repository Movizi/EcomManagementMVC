using EcomManagement.Contracts;
using EcomManagement.Data;
using EcomManagement.Models.Suppliers;
using Microsoft.Extensions.Logging.Abstractions;

namespace EcomManagement.Repositories
{
    public class SupplierRepository : ICrudRepository<Supplier>
    {
        #region Injection
        private readonly AppDbContext _context;
        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Main Operations
        public List<Supplier> Get()
        {
            return _context.Suppliers.ToList();
        }

        public Supplier GetById(int id)
        {
            if (id == 0)
                return null;

            return _context.Suppliers.FirstOrDefault(x => x.SupplierID == id);
        }

        public Supplier Add(Supplier entity)
        {
            if (entity == null)
                return null;

            _context.Suppliers.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Supplier Update(Supplier entity)
        {
            if (entity == null)
                return null;

            _context.Suppliers.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public Supplier Delete(int id)
        {
            if (id == 0)
                return null;

            var entity = _context.Suppliers.FirstOrDefault(x => x.SupplierID == id);

            if (entity == null)
                return null;

            _context.Suppliers.Remove(entity);
            _context.SaveChanges();

            return entity;
        }

        #endregion
    }
}

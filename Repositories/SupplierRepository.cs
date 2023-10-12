using EcomManagement.Contracts;
using EcomManagement.Data;
using EcomManagement.Models.Suppliers;

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

        public Supplier Add(Supplier entity)
        {
            try
            {
                _context.Suppliers.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Supplier Delete(int id)
        {
            try
            {
                var entity = _context.Suppliers.FirstOrDefault(x => x.SupplierID == id);

                _context.Suppliers.Remove(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Supplier> Get()
        {
            try
            {
                return _context.Suppliers.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Supplier GetById(int id)
        {
            try
            {
                return _context.Suppliers.FirstOrDefault(x => x.SupplierID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Supplier Update(Supplier entity)
        {
            try
            {
                _context.Suppliers.Update(entity);
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

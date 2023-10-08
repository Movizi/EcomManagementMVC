using EcomManagement.Contracts;
using EcomManagement.Data;
using EcomManagement.Models.Shippers;

namespace EcomManagement.Repositories
{
    public class ShipperRepository : ICrudRepository<Shipper>
    {
        #region Injection
        private readonly AppDbContext _context;
        public ShipperRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        public Shipper Add(Shipper entity)
        {
            try
            {
                _context.Shippers.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _context.Shippers.FirstOrDefault(x => x.ShipperID == id);

                _context.Shippers.Remove(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Shipper> Get()
        {
            try
            {
                return _context.Shippers.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Shipper GetById(int id)
        {
            try
            {
                return _context.Shippers.FirstOrDefault(x => x.ShipperID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Shipper Update(Shipper entity)
        {
            try
            {
                _context.Shippers.Update(entity);
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

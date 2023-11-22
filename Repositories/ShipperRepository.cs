using EcomManagement.Contracts;
using EcomManagement.Data;
using EcomManagement.Models.Shippers;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

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

        #region Main Operations
        public List<Shipper> Get()
        {
            return _context.Shippers.ToList();
        }

        public Shipper GetById(int id)
        {
            if (id == 0)
                return null;

            return _context.Shippers.FirstOrDefault(x => x.ShipperID == id);
        }

        public Shipper Add(Shipper entity)
        {
            if (entity == null)
                return null;

            _context.Shippers.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public Shipper Update(Shipper entity)
        {
            if (entity == null)
                return null;

            _context.Shippers.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public Shipper Delete(int id)
        {
            if (id == 0)
                return null;

            var entity = _context.Shippers.FirstOrDefault(x => x.ShipperID == id);

            if (entity == null)
                return null;

            _context.Shippers.Remove(entity);
            _context.SaveChanges();

            return entity;
        }

        #endregion
    }
}

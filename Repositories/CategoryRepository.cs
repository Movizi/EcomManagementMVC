using EcomManagement.Contracts;
using EcomManagement.Data;
using EcomManagement.Models.Categories;

namespace EcomManagement.Repositories
{
    public class CategoryRepository : ICrudRepository<Category>
    {
        #region Injection
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Main Operations

        public List<Category> Get()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            if (id == 0)
                return null;

            return _context.Categories.FirstOrDefault(x => x.CategoryID == id);
        }

        public Category Add(Category entity)
        {

            if (entity == null)
                return null;

            _context.Categories.Add(entity);

            _context.SaveChanges();

            return entity;
        }

        public Category Update(Category entity)
        {
            if (entity == null)
                return null;

            _context.Categories.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public Category Delete(int id)
        {
            if (id == 0)
                return null;

            var category = _context.Categories.FirstOrDefault(x => x.CategoryID == id);

            if (category == null)
                return null;

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return category;
        }

        #endregion
    }
}

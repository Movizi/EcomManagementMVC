using EcomManagement.Contracts;
using EcomManagement.Data;
using EcomManagement.Models.Categories;
using System.Collections.ObjectModel;

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

        public Category Add(Category entity)
        {
            try
            {
                _context.Categories.Add(entity);

                _context.SaveChanges();

                return entity;

            }
            catch(Exception)
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> Get()
        {
            try
            {
                return _context.Categories.ToList();
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Category GetById(int id)
        {
            try
            {
                return _context.Categories.FirstOrDefault(x => x.CategoryID == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Category Update(Category entity)
        {
            _context.Categories.Update(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}

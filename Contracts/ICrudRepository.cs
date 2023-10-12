namespace EcomManagement.Contracts
{
    public interface ICrudRepository<T>
    {
        public List<T> Get();
        public T GetById(int id);
        public T Add (T entity);
        public T Update(T entity);
        public T Delete(int id);
    }
}

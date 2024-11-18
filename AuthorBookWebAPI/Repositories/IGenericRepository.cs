namespace AuthorBookWebAPI.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        public T Get(int id);
        public IQueryable<T> GetAll();
        public int Add(T entity);
        public T Update(T entity);
        public void Delete(T entity);
    }
}

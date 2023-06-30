namespace CRUD.Repositories
{
    public interface IGenericRepository<T> where T : class 
    {
        Task<T> CreateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}

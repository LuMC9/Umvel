using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CRUDDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(CRUDDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _dbSet.FindAsync(id);
        }
    }
}

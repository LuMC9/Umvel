using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repositories
{
    public class SalesRepository : GenericRepository<Sale> , ISalesRepository
    {
        private CRUDDbContext _dbContext;
        public SalesRepository(CRUDDbContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Sale>> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            var result = await _dbContext.Sales.Where(x => x.Date.Date >= fromDate.Date && x.Date.Date <= toDate.Date)
                        .Include(x=>x.Customer)
                        .AsNoTracking()
                        .ToListAsync();

            return result;
        }
    }
}

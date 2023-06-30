using CRUD.Models;

namespace CRUD.Repositories
{
    public interface ISalesRepository : IGenericRepository<Sale>
    {
        Task<IEnumerable<Sale>> GetByDateRange(DateTime fromDate, DateTime toDate);

    }
}

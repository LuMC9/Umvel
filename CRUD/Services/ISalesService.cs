using CRUD.DTO;
using CRUD.Models;

namespace CRUD.Services
{
    public interface ISalesService
    {
        Task<Sale> CreateAsync(SaleDTO saleDTO);
        Task<IEnumerable<Sale>> GetByDateRange(DateTime fromDate, DateTime toDate);
        Task<Sale> CancelSale(int id);
     }
}

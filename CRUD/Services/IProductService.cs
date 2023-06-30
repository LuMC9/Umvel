using CRUD.DTO;
using CRUD.Models;

namespace CRUD.Services
{
    public interface IProductService
    {
        Task<Product> CreateAsync(ProductDTO productDto);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
    }
}
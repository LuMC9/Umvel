using CRUD.DTO;
using CRUD.Models;

namespace CRUD.Services
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(CustomerDTO customer);
        Task<IEnumerable<Customer>> GetAllClientsAsync();
        Task<Customer> GetByIdAsync(int id);


    }
}

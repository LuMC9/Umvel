using AutoMapper;
using CRUD.DTO;
using CRUD.Models;
using CRUD.Repositories;

namespace CRUD.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Customer> CreateCustomerAsync(CustomerDTO customerDto)
        {
            Customer customer = _mapper.Map<Customer>(customerDto);
            customer = await _repository.CreateAsync(customer);

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllClientsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}

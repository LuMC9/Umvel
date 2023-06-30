using AutoMapper;
using CRUD.DTO;
using CRUD.Models;
using CRUD.Repositories;

namespace CRUD.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public SalesService(ISalesRepository salesRepository, ICustomerRepository customerRepo, IMapper mapper)
        {
            _salesRepository = salesRepository;
            _customerRepository = customerRepo;
            _mapper = mapper;
        }

        public async Task<Sale> CreateAsync(SaleDTO saleDTO)
        {
            Customer customer = await _customerRepository.GetByIdAsync(saleDTO.CustomerId);
            if(customer is not null)
            {
                Sale sale = _mapper.Map<Sale>(saleDTO);
                sale.Customer = customer;

                sale = await _salesRepository.CreateAsync(sale);

                return sale;            }

            return null;
        }

        public async Task<IEnumerable<Sale>> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            var sales = await _salesRepository.GetByDateRange(fromDate, toDate);
            
            return sales;
        }

        public async Task<Sale> CancelSale(int id)
        {
            Sale sale = await _salesRepository.GetByIdAsync(id);
            if(sale != null)
            {
                sale.Status = Enums.Enums.SaleStatus.Cancelled.ToString();
                sale = await _salesRepository.UpdateAsync(sale);

                return sale;
            }

            return null;
        }
    }
}

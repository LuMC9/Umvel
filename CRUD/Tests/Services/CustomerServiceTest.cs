using AutoMapper;
using CRUD.DTO;
using CRUD.Mapper;
using CRUD.Models;
using CRUD.Repositories;
using CRUD.Services;
using Moq;
using Xunit;

namespace CRUD.Tests.Services
{
    public class CustomerServiceTest
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CustomerService _customerService;

        public CustomerServiceTest()
        {
            _mockCustomerRepo = new Mock<ICustomerRepository>();
            _mockMapper = new Mock<IMapper>();
            _customerService = new CustomerService(_mockCustomerRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task CreateCustomerAsync_Test()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CustomerProfile>());
            var _mapper = config.CreateMapper();
            CustomerDTO customerDto = new()
            {
                Name = "Juan"
            };
            Customer customer = new Customer();
            customer = _mapper.Map<Customer>(customerDto);
            _mockCustomerRepo.Setup(x => x.CreateAsync(It.IsAny<Customer>())).ReturnsAsync(customer).Verifiable();
            var response = await _customerService.CreateCustomerAsync(customerDto);

            Assert.NotNull(customer);
            Assert.Equal(customerDto.Name, customer.Name);
            Assert.NotNull(response);
            _mockCustomerRepo.Verify();
        }

        [Fact]
        public async Task GetAllClientsAsync_ReturnsListTest()
        {
            List<Customer> customers = new();

            _mockCustomerRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(customers).Verifiable();
            var response = await _customerService.GetAllClientsAsync();

            Assert.NotNull(response);
            _mockCustomerRepo.Verify();
        }

        [Fact]
        public async Task GetByIdAsync_Test()
        {
            Customer customers = new();

            _mockCustomerRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(customers).Verifiable();
            var response = await _customerService.GetAllClientsAsync();

            Assert.NotNull(response);
            _mockCustomerRepo.Verify();
        }

    }
}

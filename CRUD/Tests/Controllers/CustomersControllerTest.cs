using CRUD.Controllers;
using CRUD.DTO;
using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CRUD.Tests.Controllers
{
    public class CustomersControllerTest
    {
        private readonly Mock<ICustomerService> _mockCustomerService;
        private readonly CustomerController _customerController;

        public CustomersControllerTest()
        {
            _mockCustomerService = new Mock<ICustomerService>();
            _customerController = new CustomerController(_mockCustomerService.Object);
        }

        [Fact]
        public async Task CreateAsyncTest()
        {
            var customer = new Customer();
            var customerDTO = new CustomerDTO();

            _mockCustomerService.Setup(x => x.CreateCustomerAsync(It.IsAny<CustomerDTO>())).ReturnsAsync(customer).Verifiable();
            var result = await _customerController.CreateAsync(customerDTO);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            _mockCustomerService.Verify();
        }

        [Fact]
        public async Task GetAllAsyncTest()
        {
            var customers = new List<Customer>() { new Customer() { Name="Juan"} };

            _mockCustomerService.Setup(x => x.GetAllClientsAsync()).ReturnsAsync(customers).Verifiable();
            var result = await _customerController.GetAllAsync();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            _mockCustomerService.Verify();
        }

        [Fact]
        public async Task GetByIdAsync_OkTest()
        {
            var customer = new Customer();
            int id = 1;

            _mockCustomerService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(customer).Verifiable();
            var result = await _customerController.GetByIdAsync(id);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            _mockCustomerService.Verify();

        }

        [Fact]
        public async Task GetByIdAsync_NotFoundTest()
        {
            int id = 1;

            _mockCustomerService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Verifiable();
            var result = await _customerController.GetByIdAsync(id);

            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
            _mockCustomerService.Verify();
        }
    }
}

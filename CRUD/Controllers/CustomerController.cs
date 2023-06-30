using CRUD.DTO;
using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CustomerDTO customerDto)
        {
            Customer customer = await _customerService.CreateCustomerAsync(customerDto);

            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Customer> customers = await _customerService.GetAllClientsAsync();

            if(!customers.Any())
                return NotFound();

            return Ok(customers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Customer customer = await _customerService.GetByIdAsync(id);

            if(customer is null)
                return NotFound();

            return Ok(customer);
        }

    }
}

using CRUD.DTO;
using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductDTO productDto)
        {
            Product product = await _productService.CreateAsync(productDto);

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<Product> products = await _productService.GetAllAsync();

            if (!products.Any())
                return NotFound();

            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Product product = await _productService.GetByIdAsync(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }
    }
}

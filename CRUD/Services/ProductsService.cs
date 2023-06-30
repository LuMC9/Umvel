using AutoMapper;
using CRUD.DTO;
using CRUD.Models;
using CRUD.Repositories;

namespace CRUD.Services
{
    public class ProductsService : IProductService
    {
        private readonly IProductsRepository _repository;
        private readonly IMapper _mapper;

        public ProductsService(IProductsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Product> CreateAsync(ProductDTO productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            product = await _repository.CreateAsync(product);

            return product;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();

            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            Product product = await _repository.GetByIdAsync(id);

            return product;
        }
    }
}

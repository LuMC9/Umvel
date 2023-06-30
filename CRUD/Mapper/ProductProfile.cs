using AutoMapper;
using CRUD.DTO;
using CRUD.Models;

namespace CRUD.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

        }
    }
}

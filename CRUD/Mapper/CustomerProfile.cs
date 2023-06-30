using AutoMapper;
using CRUD.DTO;
using CRUD.Models;

namespace CRUD.Mapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();

        }
    }
}

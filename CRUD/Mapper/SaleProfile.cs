using AutoMapper;
using CRUD.DTO;
using CRUD.Models;

namespace CRUD.Mapper
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<Sale, SaleResponseDTO>();
            CreateMap<SaleResponseDTO, Sale>();
            CreateMap<Sale, SaleDTO>();
            CreateMap<SaleDTO, Sale>();

        }
    }
}

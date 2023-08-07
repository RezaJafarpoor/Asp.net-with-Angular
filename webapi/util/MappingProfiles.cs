using AutoMapper;
using Core.Entities;
using webapi.DTO;

namespace webapi.util
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(p =>p.PictureUrl, o =>o.MapFrom<ProductUrlResolver>());
                
        }
    }
}

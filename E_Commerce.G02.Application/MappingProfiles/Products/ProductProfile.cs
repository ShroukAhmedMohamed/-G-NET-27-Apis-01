using AutoMapper;
using E_Commerce.G02.Application.DTOs.Products;
using E_Commerce.G02.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.G02.Application.MappingProfiles.Products
{
    public class ProductProfile : Profile

    {

        
 
        public ProductProfile()

        {

            CreateMap<productBrand, BrandDto>();

            CreateMap<ProductType, TypeDto>();

            CreateMap<product, ProductDto>()

            .ForMember(D => D.ProductBrand, opt => opt.MapFrom(s => s.Brand.Name))

           .ForMember(D => D.ProductType, opt => opt.MapFrom(s => s.Type.Name))
           //.ForMember(D => D.PictureUrl, opt => opt.MapFrom(s => $"/{s.PictureUrl}"))
           .ForMember(D => D.PictureUrl, opt => opt.MapFrom<PictureUrlResolver>())
           ;

                





        }

    }


}

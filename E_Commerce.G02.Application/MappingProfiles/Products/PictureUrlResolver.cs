using AutoMapper;
using E_Commerce.G02.Application.DTOs.Products;
using E_Commerce.G02.Domain.Entities.Products;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.G02.Application.MappingProfiles.Products
{
    public class PictureUrlResolver(IConfiguration configuration) : IValueResolver<product, ProductDto, string>

    {


        public string Resolve(product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            return $"{configuration["BaseUrl"]}/{source.PictureUrl}";


        }
    }

   
}


using AutoMapper;
using E_Commerce.G02.Application.Common;
using E_Commerce.G02.Application.DTOs.Products;
using E_Commerce.G02.Application.Services.Contracts;
using E_Commerce.G02.Domain.contracts;
using E_Commerce.G02.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.G02.Application.Services.Class
{
    public class ProductService(IUnitOfWork unitOfwork, IMapper mapper) : IProductService


    {
        public async Task<Result<IReadOnlyList<BrandDto>>> GetAllBrandsAsync(CancellationToken ct = default)
        {
            var brands = await unitOfwork.GetRepository<productBrand, int>().GetAllAsync(ct);

            // Mapping

            var brandDtos = mapper.Map<IReadOnlyList<BrandDto>>(brands);

            return Result<IReadOnlyList<BrandDto>>.Ok(brandDtos);
        }

        public async Task<Result<IReadOnlyList<ProductDto>>> GetAllProductsAsync(CancellationToken ct = default)
        {


            var products = await unitOfwork.GetRepository<product, int>().GetAllAsync(ct);

            var productDtos = mapper.Map<IReadOnlyList<ProductDto>>(products);

            return Result<IReadOnlyList<ProductDto>>.Ok(productDtos);




        }

        public async Task<Result<IReadOnlyList<TypeDto>>> GetAllTypesAsync(CancellationToken ct = default)

        {

            var types = await unitOfwork.GetRepository<ProductType, int>().GetAllAsync(ct);

            var typeDtos = mapper.Map<IReadOnlyList<TypeDto>>(types);

            return Result<IReadOnlyList<TypeDto>>.Ok(typeDtos);

        }

        public async Task<Result<ProductDto>> GetProductByIdAsync(int id, CancellationToken ct = default)

        {

            var product = await unitOfwork.GetRepository<product, int>().GetByIdAsync(id, ct);

            if (product is null)

            {

                return Result<ProductDto>.Fail(Error.NotFound("Product. NotFound", $"Product With Id {id} Is Not Found!"));

            }



            var productDto = mapper.Map<ProductDto>(product);

            return Result<ProductDto>.Ok(productDto);
        }

    
    }
}


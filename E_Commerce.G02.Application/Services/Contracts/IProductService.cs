using E_Commerce.G02.Application.Common;
using E_Commerce.G02.Application.DTOs.Products;
using E_Commerce.G02.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.G02.Application.Services.Contracts
{
    public interface IProductService
    {

       

Task<Result<IReadOnlyList<ProductDto>>> GetAllProductsAsync(CancellationToken ct= default);
Task<Result<ProductDto>> GetProductByIdAsync(int id, CancellationToken ct = default);
Task<Result<IReadOnlyList<BrandDto>>> GetAllBrandsAsync(CancellationToken ct = default);
Task<Result<IReadOnlyList<TypeDto>>> GetAllTypesAsync(CancellationToken ct = default);




    }
}
using E_Commerce.G02.Application.DTOs.Products;
using E_Commerce.G02.Application.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.G02.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ApiBaseController

    {
        // GET: api/products

        [HttpGet]

     public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAllProducts(CancellationToken ct = default)

        {

            var result = await productService.GetAllProductsAsync(ct);

            return ToActionResult(result);

        }

        // GET: api/products

        [HttpGet("brands")]

       

       public async Task<ActionResult<IReadOnlyList<BrandDto>>> GetAllBrands(CancellationToken ct= default)

        {

            var result = await productService.GetAllBrandsAsync(ct);

            return ToActionResult(result);

        }

        // GET: api/types


        [HttpGet("types")]

        

      public async Task<ActionResult<IReadOnlyList<TypeDto>>> GetAllTypes(CancellationToken ct = default)

        {

            var result = await productService.GetAllTypesAsync(ct);

            return ToActionResult(result);

        }

        // GET: api/id


        [HttpGet("{id}")]

      

       public async Task<ActionResult<ProductDto>> GetProductById(int id, CancellationToken ct= default)

        {

            var result = await productService.GetProductByIdAsync(id, ct);

            return ToActionResult(result);

        }


    }
}

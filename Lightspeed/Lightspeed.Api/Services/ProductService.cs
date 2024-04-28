using Lightspeed.Api.Authorization;
using Lightspeed.Api.Exceptions;
using Lightspeed.Api.Models.Responses.Products;
using Lightspeed.Api.Services.Interfaces;

namespace Lightspeed.Api.Services;

public class ProductService : ServiceBase, IProductService
{
    public ProductService(ApiSecrets apiSecrets, HttpClient httpClient) : base(apiSecrets, httpClient)
    {
    }

    public async Task<Product> GetProductAsync(int productId)
    {
        var result = await GetApiResult<ProductContainer<Product>>(HttpMethod.Get, $"/products/{productId}.json");
        return result?.Product ?? throw new NotFoundException();
    }

    public async Task<ProductPostResponse> CreateProductAsync(ProductPost product)
    {
        var result = await GetApiResult<ProductContainer<ProductPostResponse>>(
            HttpMethod.Post,
            "/products.json",
            new { product });
        
        return result?.Product ?? throw new NotFoundException();
    }

    public async Task AddImageAsync(int productId, string fileName, byte[] contents)
    {
        await CallApi(
            HttpMethod.Post,
            $"/products/{productId}/images.json",
            new
            {
                productImage = new
                {
                    filename = fileName,
                    attachment = Convert.ToBase64String(contents)
                }
            });
    }
}
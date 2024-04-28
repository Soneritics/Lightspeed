using Lightspeed.Api.Models.Responses.Products;

namespace Lightspeed.Api.Services.Interfaces;

public interface IProductService
{
    Task<Product> GetProductAsync(int productId);

    Task<ProductPostResponse> CreateProductAsync(ProductPost product);

    Task AddImageAsync(int productId, string fileName, byte[] contents);
}
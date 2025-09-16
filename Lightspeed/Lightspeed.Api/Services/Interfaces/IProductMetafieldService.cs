using Lightspeed.Api.Models.Responses.ProductMetafields;

namespace Lightspeed.Api.Services.Interfaces;

public interface IProductMetafieldService
{
    Task<ProductMetafieldList> GetAllAsync(int productId, int page = 1);
    
    Task CreateAsync(int productId, string key, string value);
    
    Task UpdateAsync(int productId, int metafieldId, string key, string value);
}
using Lightspeed.Api.Authorization;
using Lightspeed.Api.Models.Responses.ProductMetafields;
using Lightspeed.Api.Models.Responses.Webhooks;
using Lightspeed.Api.Services.Interfaces;

namespace Lightspeed.Api.Services;

public class ProductMetafieldService : ServiceBase, IProductMetafieldService
{
    public ProductMetafieldService(ApiSecrets apiSecrets, HttpClient httpClient) : base(apiSecrets, httpClient)
    {
    }
    
    public async Task<ProductMetafieldList> GetAllAsync(int productId, int page = 1)
    {
        return await GetApiResult<ProductMetafieldList>(
            HttpMethod.Get,
            $"/products/{productId}/metafields.json") ?? new ProductMetafieldList();
    }

    public async Task CreateAsync(int productId, string key, string value)
    {
        await CallApi(
            HttpMethod.Post,
            $"/products/{productId}/metafields.json",
            new
            {
                productMetafield = new
                {
                    key,
                    value
                }
            });
    }

    public async Task UpdateAsync(int productId, int metafieldId, string key, string value)
    {
        await CallApi(
            HttpMethod.Post,
            $"/products/{productId}/metafields/{metafieldId}.json",
            new
            {
                productMetafield = new
                {
                    key,
                    value
                }
            });
    }
}
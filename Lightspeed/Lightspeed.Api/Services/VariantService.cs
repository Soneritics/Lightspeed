using Lightspeed.Api.Authorization;
using Lightspeed.Api.Models.Responses.Variants;
using Lightspeed.Api.Services.Interfaces;

namespace Lightspeed.Api.Services;

public class VariantService : ServiceBase, IVariantService
{
    public VariantService(ApiSecrets apiSecrets, HttpClient httpClient) : base(apiSecrets, httpClient)
    {
    }

    public async Task CreateVariantAsync(VariantPost variant)
    {
        await CallApi(
            HttpMethod.Post,
            "/variants.json",
            new VariantContainer<VariantPost>()
            {
                Variant = variant
            });
    }

    public async Task DeleteVariantAsync(int variantId)
    {
        await CallApi(HttpMethod.Delete, $"/variants/{variantId}.json");
    }

    public async Task<IEnumerable<Variant>> GetVariantsByProductAsync(int productId)
    {
        var result = await GetApiResult<VariantsContainer<Variant>>(
            HttpMethod.Get,
            $"/variants.json?product={productId}");

        return result?.Variants ?? Enumerable.Empty<Variant>();
    }
}
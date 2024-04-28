using Lightspeed.Api.Models.Responses.Variants;

namespace Lightspeed.Api.Services.Interfaces;

public interface IVariantService
{
    Task CreateVariantAsync(VariantPost variant);
    Task DeleteVariantAsync(int variantId);
    Task<IEnumerable<Variant>> GetVariantsByProductAsync(int productId);
}
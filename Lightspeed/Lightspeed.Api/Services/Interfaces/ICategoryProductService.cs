namespace Lightspeed.Api.Services.Interfaces;

public interface ICategoryProductService
{
    Task AddProductToCategoriesAsync(IEnumerable<int> categories, int productId);
}
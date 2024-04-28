using Lightspeed.Api.Authorization;
using Lightspeed.Api.Models.Responses.Categories;
using Lightspeed.Api.Services.Interfaces;

namespace Lightspeed.Api.Services;

public class CategoryProductService : ServiceBase, ICategoryProductService
{
    public CategoryProductService(ApiSecrets apiSecrets, HttpClient httpClient) : base(apiSecrets, httpClient)
    {
    }

    public async Task AddProductToCategoriesAsync(IEnumerable<int> categories, int productId)
    {
        await GetApiResult<CategoryContainer<CategoryPostResponse>>(
            HttpMethod.Post,
            "/categories/products/bulk.json",
            new
            {
                categoriesProduct = new
                {
                    categories = categories.ToArray(),
                    product = productId
                }
            });
    }
}
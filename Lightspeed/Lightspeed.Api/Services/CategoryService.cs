using Lightspeed.Api.Authorization;
using Lightspeed.Api.Exceptions;
using Lightspeed.Api.Models.Responses.Categories;
using Lightspeed.Api.Services.Interfaces;

namespace Lightspeed.Api.Services;

public class CategoryService : ServiceBase, ICategoryService
{
    public CategoryService(ApiSecrets apiSecrets, HttpClient httpClient) : base(apiSecrets, httpClient)
    {
    }

    public async Task<CategoryPostResponse> CreateCategoryAsync(CategoryPost category)
    {
        var result = await GetApiResult<CategoryContainer<CategoryPostResponse>>(
            HttpMethod.Post,
            "/categories.json",
            new { category });
        
        return result?.Category ?? throw new NotFoundException();
    }
}
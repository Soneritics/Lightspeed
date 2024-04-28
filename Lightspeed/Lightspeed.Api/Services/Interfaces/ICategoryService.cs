using Lightspeed.Api.Models.Responses.Categories;

namespace Lightspeed.Api.Services.Interfaces;

public interface ICategoryService
{
    Task<CategoryPostResponse> CreateCategoryAsync(CategoryPost category);
}
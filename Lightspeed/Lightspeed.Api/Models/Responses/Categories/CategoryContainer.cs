namespace Lightspeed.Api.Models.Responses.Categories;

public class CategoryContainer<T>
    where T : class
{
    public T Category { get; set; }
}
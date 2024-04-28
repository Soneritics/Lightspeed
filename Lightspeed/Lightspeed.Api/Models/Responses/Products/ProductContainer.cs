namespace Lightspeed.Api.Models.Responses.Products;

public class ProductContainer<T>
    where T : class
{
    public T Product { get; set; }
}
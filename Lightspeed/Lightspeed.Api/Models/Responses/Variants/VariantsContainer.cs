namespace Lightspeed.Api.Models.Responses.Variants;

public class VariantsContainer<T>
    where T : class
{
    public IEnumerable<T> Variants { get; set; }
}
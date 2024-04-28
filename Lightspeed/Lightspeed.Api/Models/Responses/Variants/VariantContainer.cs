namespace Lightspeed.Api.Models.Responses.Variants;

public class VariantContainer<T>
    where T : class
{
    public T Variant { get; set; }
}
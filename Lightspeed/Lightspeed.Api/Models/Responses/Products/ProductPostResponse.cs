namespace Lightspeed.Api.Models.Responses.Products;

public class ProductPostResponse
{
    public int Id { get; set; }
    public bool IsVisible { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Url { get; set; }
}
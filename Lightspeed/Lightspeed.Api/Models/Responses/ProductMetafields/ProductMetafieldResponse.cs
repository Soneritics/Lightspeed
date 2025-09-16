namespace Lightspeed.Api.Models.Responses.ProductMetafields;

public class ProductMetafieldResponse
{
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
    
    public string Key { get; set; }
    
    public string Value { get; set; }
}
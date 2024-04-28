namespace Lightspeed.Api.Models.Responses.Products;

public class ProductPost
{
    public string Visibility { get; set; }
    public string Title { get; set; }
    public string Fulltitle { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public int Deliverydate { get; set; } = 0;
    public int Supplier { get; set; } = 0;
    public int Brand { get; set; } = 0;
    public string Data01 { get; set; } = string.Empty;
    public string Data02 { get; set; } = string.Empty;
    public string Data03 { get; set; } = string.Empty;
}
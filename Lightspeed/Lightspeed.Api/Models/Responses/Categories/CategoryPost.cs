namespace Lightspeed.Api.Models.Responses.Categories;

public class CategoryPost
{
    public bool IsVisible { get; set; }
    public string Type { get; set; } = "category";
    public string Title { get; set; }
    public string Fulltitle { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public int Parent { get; set; } = 0;
}
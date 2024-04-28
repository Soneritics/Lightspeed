namespace Lightspeed.Api.Models.Responses.Categories;

public class Category
{
    public int Id { get; set; }
    public bool IsVisible { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Url { get; set; }
}
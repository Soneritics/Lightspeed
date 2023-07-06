namespace Lightspeed.Api.Models.Generic;

public class Metafield
{
    public string Id { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string OwnerType { get; set; } = string.Empty;
    public int OwnerId { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
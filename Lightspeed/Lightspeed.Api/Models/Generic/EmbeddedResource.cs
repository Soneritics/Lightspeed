namespace Lightspeed.Api.Models.Generic;

public class EmbeddedResource<T>
    where T : new()
{
    public string Id { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public T Embedded { get; set; } = new ();
}
namespace Lightspeed.Api.Models.Generic;

public class Embedded<T>
    where T : new()
{
    public EmbeddedResource<T> Resource { get; set; } = new ();
}
namespace Lightspeed.Api.Models.Generic;

public class EmbeddedGenericResource<T> : EmbeddedResource
    where T : new()
{
    public T Embedded { get; set; } = new ();
}
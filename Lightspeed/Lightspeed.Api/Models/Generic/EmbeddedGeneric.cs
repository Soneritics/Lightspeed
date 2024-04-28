namespace Lightspeed.Api.Models.Generic;

public class EmbeddedGeneric<T>
    where T : new()
{
    public EmbeddedGenericResource<T> Resource { get; set; } = new ();
}
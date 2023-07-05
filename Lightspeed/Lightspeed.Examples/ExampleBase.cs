using Lightspeed.Api;
using Lightspeed.Api.Authorization;

namespace Lightspeed.Examples;

public abstract class ExampleBase
{
    protected readonly LightspeedApi Api;

    protected ExampleBase(ApiSecrets apiSecrets)
    {
        Api = new LightspeedApi(apiSecrets);
    }
}
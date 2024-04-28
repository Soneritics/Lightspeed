using Lightspeed.Api.Authorization;
using Lightspeed.Api.Services.Interfaces;

namespace Lightspeed.Api.Services;

public class RedirectService : ServiceBase, IRedirectService
{
    public RedirectService(ApiSecrets apiSecrets, HttpClient httpClient) : base(apiSecrets, httpClient)
    {
    }

    public async Task CreateRedirectAsync(
        string url,
        string target,
        bool isPermanent = true)
    {
        await CallApi(
            HttpMethod.Post,
            "/redirects.json",
            new
            {
                redirect = new
                {
                    url,
                    target,
                    isPermanent
                }
            });
    }
}
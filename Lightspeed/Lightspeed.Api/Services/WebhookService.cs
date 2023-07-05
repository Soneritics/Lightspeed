using Lightspeed.Api.Authorization;
using Lightspeed.Api.Models.Responses.Webhooks;
using Lightspeed.Api.Services.Interfaces;

namespace Lightspeed.Api.Services;

public class WebhookService : ServiceBase, IWebhookService
{
    public WebhookService(ApiSecrets apiSecrets, HttpClient httpClient) : base(apiSecrets, httpClient)
    {
    }
    
    public async Task<WebhookList> GetAllWebhooksAsync()
    {
        return await GetApiResult<WebhookList>(
            HttpMethod.Get,
            "/webhooks.json") ?? new WebhookList();
    }
}
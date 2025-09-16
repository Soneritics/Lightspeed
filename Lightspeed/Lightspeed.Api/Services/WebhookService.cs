using Lightspeed.Api.Authorization;
using Lightspeed.Api.Models.Requests;
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

    public async Task DeleteWebhookAsync(int webhookId)
    {
        await CallApi(HttpMethod.Delete, $"/webhooks/{webhookId}.json");
    }

    public async Task CreateWebhookAsync(WebhookRequest webhookRequest)
    {
        await CallApi(
            HttpMethod.Post,
            "/webhooks.json",
            new
            {
                webhook = webhookRequest
            });
    }
}
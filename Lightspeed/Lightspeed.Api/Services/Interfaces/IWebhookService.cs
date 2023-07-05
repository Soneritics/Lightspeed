using Lightspeed.Api.Models.Requests;
using Lightspeed.Api.Models.Responses.Webhooks;

namespace Lightspeed.Api.Services.Interfaces;

public interface IWebhookService
{
    Task<WebhookList> GetAllWebhooksAsync();
    
    Task DeleteWebhookAsync(int webhookId);
    
    Task CreateWebhookAsync(WebhookRequest webhookRequest);
}
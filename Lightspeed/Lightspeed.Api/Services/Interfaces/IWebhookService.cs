using Lightspeed.Api.Models.Responses.Webhooks;

namespace Lightspeed.Api.Services.Interfaces;

public interface IWebhookService
{
    Task<WebhookList> GetAllWebhooksAsync();
}
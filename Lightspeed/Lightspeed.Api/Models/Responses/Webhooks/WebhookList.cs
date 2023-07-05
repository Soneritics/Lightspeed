namespace Lightspeed.Api.Models.Responses.Webhooks;

public class WebhookList
{
    public List<WebhookResponse> Webhooks { get; set; } = new ();
}
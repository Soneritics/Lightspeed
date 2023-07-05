using Lightspeed.Api.Authorization;

namespace Lightspeed.Examples.Examples;

public class WebhookExample : ExampleBase, IExample
{
    public WebhookExample(ApiSecrets apiSecrets) : base(apiSecrets)
    {
    }

    public async Task RunAsync()
    {
        var webhooks = await Api.WebhookService.GetAllWebhooksAsync();

        Console.WriteLine($"Found {webhooks.Webhooks.Count} webhooks.");

        if (webhooks.Webhooks.Any())
        {
            Console.WriteLine(
                webhooks
                    .Webhooks
                    .Select(w => w.Address)
                    .Aggregate((a, b) => $"{a}\n{b}"));
        }
    }
}
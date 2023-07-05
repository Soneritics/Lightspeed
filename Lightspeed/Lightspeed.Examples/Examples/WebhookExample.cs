using Lightspeed.Api.Authorization;
using Lightspeed.Api.Models.Requests;

namespace Lightspeed.Examples.Examples;

public class WebhookExample : ExampleBase, IExample
{
    private const string apiUrl = "https://example.com/webhook/orders/test";
    public WebhookExample(ApiSecrets apiSecrets) : base(apiSecrets)
    {
    }

    public async Task RunAsync()
    {
        await ShowCurrentWebhooksAsync();
        await CreateWebhookAsync();
        await ShowCurrentWebhooksAsync();
        await DeleteWebhookAsync();
        await ShowCurrentWebhooksAsync();
    }

    private async Task ShowCurrentWebhooksAsync()
    {
        var webhooks = await Api.WebhookService.GetAllWebhooksAsync();

        Console.WriteLine($"Found {webhooks.Webhooks.Count} webhooks.");

        if (webhooks.Webhooks.Any())
        {
            Console.WriteLine(
                webhooks
                    .Webhooks
                    .Select(w => $"{w.Address} (" + (w.IsActive ? "active" : "inactive") + ")")
                    .Aggregate((a, b) => $"{a}\n{b}"));
        }
    }

    private async Task CreateWebhookAsync()
    {
        Console.WriteLine("Creating webhook...");
        
        await Api.WebhookService.CreateWebhookAsync(new WebhookRequest()
        {
            Address = apiUrl,
            IsActive = false,
            Language = "nl",
            ItemGroup = "orders"
        });
        
        Console.WriteLine("Webhook created.");
    }

    private async Task DeleteWebhookAsync()
    {
        var webhooks = await Api.WebhookService.GetAllWebhooksAsync();
        var webhooksToDelete = webhooks.Webhooks.Where(w => w.Address == apiUrl);

        Console.WriteLine("Deleting webhook(s) that are created as examples...");
        foreach (var wh in webhooksToDelete)
        {
            Console.WriteLine($"Deleting webhook {wh.Id}...");
            await Api.WebhookService.DeleteWebhookAsync(wh.Id);
            Console.WriteLine($"Webhook {wh.Id} deleted.");
        }
    }
}
using System.Text.Json;
using Lightspeed.Api.Authorization;

namespace Lightspeed.Examples.Examples;

public class OrderByIdExample(ApiSecrets apiSecrets) : ExampleBase(apiSecrets), IExample
{
    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        WriteIndented = true
    };

    public async Task RunAsync()
    {
        Console.Write("Order or shipment id: ");
        var id = Console.ReadLine();

        await RunExampleWithIdAsync(int.Parse(id!));
        
        Console.Write("\nPress any key to continue...");
        Console.ReadKey();
    }
    
    private async Task RunExampleWithIdAsync(int orderId)
    {
        Console.WriteLine($"Fetching order {orderId}...");
        var order = await Api.OrderService.GetOrderAsync(orderId);

        Console.WriteLine($"Order {orderId} fetched:");
        Console.WriteLine(JsonSerializer.Serialize(order, _serializerOptions));
    }
}
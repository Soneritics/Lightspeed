using Lightspeed.Api.Authorization;
using Lightspeed.Api.Models.Requests;

namespace Lightspeed.Examples.Examples;

public class OrderExample : ExampleBase, IExample
{
    public OrderExample(ApiSecrets apiSecrets) : base(apiSecrets)
    {
    }

    public async Task RunAsync()
    {
        var orderId = await FetchAllOrders();
        await FetchOrder(orderId);
    }

    private async Task<int> FetchAllOrders()
    {
        Console.WriteLine("Fetching max 5 orders...");
        
        var orders = await Api.OrderService.GetOrdersAsync(new OrdersRequest()
        {
            Page = 1,
            Limit = 5
        });

        Console.WriteLine($"Found {orders.Orders.Count} orders.");
        return orders.Orders.First().Id;
    }
    
    private async Task FetchOrder(int orderId)
    {
        Console.WriteLine($"Fetching order {orderId}...");
        
        var order = await Api.OrderService.GetOrderAsync(orderId);

        Console.WriteLine($"Order {orderId} fetched.");
        Console.WriteLine($"Order {orderId} has {order.Products.Resource.Embedded.Count} order lines.");
    }
}
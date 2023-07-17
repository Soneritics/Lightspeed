using Lightspeed.Api.Authorization;

namespace Lightspeed.Examples.Examples;

public class ShipmentExample : ExampleBase, IExample
{
    public ShipmentExample(ApiSecrets apiSecrets) : base(apiSecrets)
    {
    }

    public async Task RunAsync()
    {
        Console.Write("Order or shipment id: ");
        var id = Console.ReadLine();

        await RunExampleWithIdAsync(id);
        
        Console.Write("\nPress any key to continue...");
        Console.ReadKey();
    }
    
    private async Task RunExampleWithIdAsync(string id)
    {
        try
        {
            var shipment = await Api.ShipmentService.GetShipmentAsync(int.Parse(id));
            Console.WriteLine($"Found shipment {shipment.Id}.");
            Console.WriteLine($"Shipment status: {shipment.Status}");
            Console.WriteLine($"Shipment number: {shipment.Number}");
            Console.WriteLine($"Shipment tracking: {shipment.TrackingCode}");
        }
        catch
        {
            try
            {
                var order = await Api.OrderService.GetOrderAsync(int.Parse(id));
                Console.WriteLine($"Found order {order.Id}.");

                var shipment = order.Shipments?.Resource.Embedded.FirstOrDefault();
                if (shipment == null)
                {
                    Console.WriteLine("Order has no shipments.");
                }
                else
                {
                    Console.WriteLine($"Found shipment {shipment.Id}.");
                    Console.WriteLine($"Shipment status: {shipment.Status}");
                    Console.WriteLine($"Shipment number: {shipment.Number}");
                    Console.WriteLine($"Shipment tracking: {shipment.TrackingCode}");
                }
            }
            catch
            {
                Console.WriteLine($"The id {id} is not a valid shipment or order id.");
            }
        }
    }
}
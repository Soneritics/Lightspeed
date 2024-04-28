using Lightspeed.Api.Authorization;
using Lightspeed.Api.Exceptions;
using Lightspeed.Api.Models.Responses.Shipments;
using Lightspeed.Api.Services.Interfaces;

namespace Lightspeed.Api.Services;

public class ShipmentService : ServiceBase, IShipmentService
{
    public ShipmentService(ApiSecrets apiSecrets, HttpClient httpClient) : base(apiSecrets, httpClient)
    {
    }

    public async Task<Shipment> GetShipmentAsync(int shipmentId)
    {
        var result = await GetApiResult<ShipmentContainer>(HttpMethod.Get, $"/shipments/{shipmentId}.json");
        return result?.Shipment ?? throw new NotFoundException();
    }

    public async Task UpdateShipmentAsync(
        int shipmentId,
        string trackingCode,
        bool shipped = true,
        bool notifyCustomer = true)
    {
        await CallApi(
            HttpMethod.Put,
            $"/shipments/{shipmentId}.json",
            new
            {
                shipment = new
                {
                    status = shipped ? "shipped" : "not_shipped",
                    trackingCode,
                    doNotifyShipped = notifyCustomer,
                    doNotifyTrackingCode = notifyCustomer
                }
            });
    }
}
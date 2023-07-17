using Lightspeed.Api.Models.Responses.Shipments;

namespace Lightspeed.Api.Services.Interfaces;

public interface IShipmentService
{
    Task<Shipment> GetShipmentAsync(int shipmentId);

    Task UpdateShipmentAsync(int shipmentId, string trackingCode, bool shipped = true, bool notifyCustomer = true);
}
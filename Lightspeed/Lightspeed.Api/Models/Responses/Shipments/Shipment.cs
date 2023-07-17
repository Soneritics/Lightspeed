namespace Lightspeed.Api.Models.Responses.Shipments;

public class Shipment
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Status { get; set; } = string.Empty;
    public string TrackingCode { get; set; } = string.Empty;
    public bool DoNotifyShipped { get; set; }
    public bool DoNotifyReadyForPickup { get; set; }
    public bool DoNotifyTrackingCode { get; set; }
}
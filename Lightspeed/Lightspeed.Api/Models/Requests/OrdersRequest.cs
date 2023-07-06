namespace Lightspeed.Api.Models.Requests;

public class OrdersRequest
{
    public int? Customer { get; set; }

    public int Limit { get; set; } = 50;
    
    public int Page { get; set; } = 1;
    
    public int SinceId { get; set; } = 0;
    
    public DateTime? CreatedAtMin { get; set; }
    
    public DateTime? CreatedAtMax { get; set; }
    
    public DateTime? UpdatedAtMin { get; set; }
    
    public DateTime? UpdatedAtMax { get; set; }
    
    public string? Fields { get; set; }
}
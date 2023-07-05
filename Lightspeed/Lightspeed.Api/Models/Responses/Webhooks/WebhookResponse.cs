using Lightspeed.Api.Models.Generic;

namespace Lightspeed.Api.Models.Responses.Webhooks;

public class WebhookResponse
{
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public bool IsActive { get; set; }
    
    public string ItemGroup { get; set; } = string.Empty;
    
    public string ItemAction { get; set; } = string.Empty;
    
    public Language Language { get; set; } = null!;
    
    public string Format { get; set; } = string.Empty;
    
    public string Address { get; set; } = string.Empty;
}
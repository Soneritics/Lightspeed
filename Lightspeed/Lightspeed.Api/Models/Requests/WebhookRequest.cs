namespace Lightspeed.Api.Models.Requests;

public class WebhookRequest
{
    public bool IsActive { get; set; } = true;
    
    public string ItemGroup { get; set; } = string.Empty;
    
    public string ItemAction { get; set; } = "*";
    
    public string Language { get; set; } = string.Empty;
    
    public string Format { get; set; } = "json";
    
    public string Address { get; set; } = string.Empty;
}
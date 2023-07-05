namespace Lightspeed.Api.Models.Status;

public class Error
{
    public int Code { get; set; }
    
    public string Method  { get; set; } = string.Empty;

    public string Request { get; set; } = string.Empty;
    
    public string Message { get; set; } = string.Empty;
}
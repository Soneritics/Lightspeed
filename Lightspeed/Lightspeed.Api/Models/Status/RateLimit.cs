namespace Lightspeed.Api.Models.Status;

public class RateLimit
{
    public int Limit { get; set; }
    
    public int Remaining { get; set; }
    
    public int Reset { get; set; }
}
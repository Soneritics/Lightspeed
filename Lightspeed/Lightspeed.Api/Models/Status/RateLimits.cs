namespace Lightspeed.Api.Models.Status;

public class RateLimits
{
    public RateLimit RateLimitPer5Min { get; set; } = null!;
    
    public RateLimit RateLimitPerHour { get; set; } = null!;
    
    public RateLimit RateLimitPerDay { get; set; } = null!;

    public RateLimits(string limit, string remaining, string reset)
    {
        var limits = limit.Split('/');
        var remainings = remaining.Split('/');
        var resets = reset.Split('/');
        
        RateLimitPer5Min = new RateLimit
        {
            Limit = int.Parse(limits[0]),
            Remaining = int.Parse(remainings[0]),
            Reset = int.Parse(resets[0])
        };
        
        RateLimitPerHour = new RateLimit
        {
            Limit = int.Parse(limits[1]),
            Remaining = int.Parse(remainings[1]),
            Reset = int.Parse(resets[1])
        };
        
        RateLimitPerDay = new RateLimit
        {
            Limit = int.Parse(limits[2]),
            Remaining = int.Parse(remainings[2]),
            Reset = int.Parse(resets[2])
        };
    }
}
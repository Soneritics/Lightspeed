namespace Lightspeed.Api.Authorization;

public class ApiSecrets
{
    public string ApiKey { get; set; }
    public string ApiSecret { get; set; }
    public Cluster Cluster { get; set; }
    public Language Language { get; set; }
}